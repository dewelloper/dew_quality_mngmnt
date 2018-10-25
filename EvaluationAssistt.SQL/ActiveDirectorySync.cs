using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.DirectoryServices;
using System.Collections.Generic;

public partial class StoredProcedures
{
    public const string ConnectionString = "Server=.; Database=EvaluationAssistt; Integrated Security=SSPI; Enlist=false";

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void ActiveDirectorySyncLocations()
    {
        #region Uygulamaya ait veritabanında mevcut lokasyonlar elde edilir

        // Uygulamaya ait veritabanında mevcut lokasyonlar elde edilir:
        var current_locations = new List<string>();

        using (var conn = new SqlConnection(ConnectionString))
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var cmd = new SqlCommand("SELECT Name FROM Locations", conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                current_locations.Add(reader.GetString(0));
            }
        }

        #endregion

        #region Active Directory'de yer alan güncel lokasyonlar elde edilir

        // Active Directory'de yer alan güncel lokasyonlar elde edilir:
        var locations = new List<string>();

        string adPathAgents = String.Empty;
        string adUsername = String.Empty;
        string adPassword = String.Empty;

        using (var conn = new SqlConnection(ConnectionString))
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var cmd = new SqlCommand("SELECT TOP (1) * FROM Settings", conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                adUsername = reader.GetString(0);
                adPassword = reader.GetString(1);
                adPathAgents = reader.GetString(2);
            }
        }

        DirectorySearcher adSearcher = new DirectorySearcher(
            new DirectoryEntry(adPathAgents, adUsername, adPassword), "objectClass=organizationalUnit",
            new string[] { "name" }, SearchScope.OneLevel);

        SearchResultCollection searchResult = adSearcher.FindAll();

        for (int i = 0; i < searchResult.Count; i++)
        {
            string location = searchResult[i].Properties["name"][0].ToString();
            locations.Add(location);
        }

        #endregion

        #region Active Directory'de olup, veritabanında olmayan lokasyonlar tespit edilip, tablo olarak SQL'e gönderilir

        // Active Directory'de olup, veritabanında olmayan lokasyonlar tespit edilip, tablo olarak SQL'e gönderilir:
        SqlDataRecord table = new SqlDataRecord(new SqlMetaData[] {
            new SqlMetaData("Name", SqlDbType.NVarChar, 50)
        });

        SqlContext.Pipe.SendResultsStart(table);
        {
            foreach (string location in locations)
            {
                // Eğer ilgili lokasyon veritabanında mevcutsa, bir sonraki lokasyona atla:
                if (current_locations.Contains(location))
                    continue;

                table.SetSqlString(0, location);

                SqlContext.Pipe.SendResultsRow(table);
            }
        }

        SqlContext.Pipe.SendResultsEnd();

        #endregion
    }

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void ActiveDirectorySyncUsers()
    {
        #region Uygulamaya ait veritabanında mevcut kullanıcılar elde edilir

        // Uygulamaya ait veritabanında mevcut kullanıcılar elde edilir:
        var current_users = new List<string>();

        using (var conn = new SqlConnection(ConnectionString))
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var cmd = new SqlCommand("SELECT LoginId FROM Agents", conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                current_users.Add(reader.GetString(0));
            }
        }

        #endregion

        #region Active Directory'de yer alan güncel kullanıcılar elde edilir

        // Active Directory'de yer alan güncel kullanıcılar elde edilir:
        var users = new List<User>();

        string adPathRoot = String.Empty;
        string adPathSupervisors = String.Empty;
        string adPathAgents = String.Empty;
        string adUsername = String.Empty;
        string adPassword = String.Empty;
        string admins = String.Empty;

        using (var conn = new SqlConnection(ConnectionString))
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var cmd = new SqlCommand("SELECT TOP (1) * FROM Settings", conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                adUsername = reader.GetString(0);
                adPassword = reader.GetString(1);
                adPathAgents = reader.GetString(2);
                adPathSupervisors = reader.GetString(3);
                adPathRoot = reader.GetString(4);
                admins = reader.GetString(5);
            }
        }

        #region Müşteri temsilcileri ve supervizörler çekilir :

        string[] paths = new string[] { adPathAgents, adPathSupervisors };

        foreach (var adPath in paths)
        {
            DirectorySearcher adSearcher = new DirectorySearcher(
            new DirectoryEntry(adPath, adUsername, adPassword), "objectClass=user",
            new string[] { "sn", "givenName", "sAMAccountName", "ipPhone" }, SearchScope.Subtree);

            adSearcher.PageSize = 10000;

            SearchResultCollection searchResult = adSearcher.FindAll();

            for (int i = 0; i < searchResult.Count; i++)
            {
                if (!(searchResult[i].Properties["sAMAccountName"].Count > 0) || !(searchResult[i].Properties["givenName"].Count > 0) || !(searchResult[i].Properties["sn"].Count > 0))
                    continue;

                string loginId = searchResult[i].Properties["sAMAccountName"][0].ToString();
                string firstName = searchResult[i].Properties["givenName"][0].ToString();
                string lastName = searchResult[i].Properties["sn"][0].ToString();
                string ipPhone = (searchResult[i].Properties["ipPhone"].Count > 0) ? searchResult[i].Properties["ipPhone"][0].ToString() : String.Empty;

                if (loginId.Contains("test") || firstName.Contains("test") || lastName.Contains("test"))
                    continue;

                var exists = users.Find(x => x.LoginId == loginId);
                if (exists != null || current_users.Contains(loginId))
                    continue;

                users.Add(new User()
                {
                    LoginId = loginId,
                    FirstName = firstName,
                    LastName = lastName,
                    IpPhone = ipPhone
                });
            }
        }

        #endregion

        #region Adminler çekilir :

        string[] adminUsers = admins.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var admin in adminUsers)
        {
            DirectorySearcher adSearcherAdmins = new DirectorySearcher(
            new DirectoryEntry(adPathRoot, adUsername, adPassword), "objectClass=user",
            new string[] { "sn", "givenName", "sAMAccountName" }, SearchScope.Subtree);

            adSearcherAdmins.Filter = String.Format("(sAMAccountName={0})", admin);

            SearchResult searchResultAdmins = adSearcherAdmins.FindOne();

            if (searchResultAdmins == null)
                continue;

            string loginId = searchResultAdmins.Properties["sAMAccountName"][0].ToString();
            string firstName = searchResultAdmins.Properties["givenName"][0].ToString();
            string lastName = searchResultAdmins.Properties["sn"][0].ToString();

            var exists = users.Find(x => x.LoginId == loginId);
            if (exists != null || current_users.Contains(loginId))
                continue;

            users.Add(new User()
            {
                LoginId = loginId,
                FirstName = firstName,
                LastName = lastName
            });
        }

        #endregion

        users.Sort((x, y) => x.LoginId.CompareTo(y.LoginId));

        #endregion

        #region Active Directory'de olup, veritabanında olmayan kullanıcılar tespit edilip, tablo olarak SQL'e gönderilir

        // Active Directory'de olup, veritabanında olmayan kullanıcılar tespit edilip, tablo olarak SQL'e gönderilir:
        SqlDataRecord table = new SqlDataRecord(new SqlMetaData[] {
            new SqlMetaData("LoginId", SqlDbType.NVarChar, 50),
            new SqlMetaData("AgentTypeId", SqlDbType.Int),
            new SqlMetaData("FirstName", SqlDbType.NVarChar, 50),
            new SqlMetaData("LastName", SqlDbType.NVarChar, 50),
            new SqlMetaData("IpPhone", SqlDbType.Char, 6)
        });

        SqlContext.Pipe.SendResultsStart(table);
        {
            foreach (User user in users)
            {
                // Eğer ilgili kullanıcı veritabanında mevcutsa, bir sonraki kullanıcıya atla:
                if (current_users.Contains(user.LoginId))
                    continue;

                table.SetSqlString(0, user.LoginId);
                // Eğer admin listesinde yer alıyorsa 1 (Admin), aksi halde 5 (Asistan) :
                table.SetSqlInt32(1, Array.IndexOf(adminUsers, user.LoginId) == -1 ? 5 : 1);
                table.SetSqlString(2, user.FirstName);
                table.SetSqlString(3, user.LastName);
                table.SetSqlString(4, user.IpPhone);

                SqlContext.Pipe.SendResultsRow(table);
            }
        }

        SqlContext.Pipe.SendResultsEnd();

        #endregion
    }

    public class User
    {
        public string LoginId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IpPhone { get; set; }
    }

    //[Microsoft.SqlServer.Server.SqlProcedure]
    //public static void ActiveDirectorySyncLocations()
    //{
    //    #region Uygulamaya ait veritabanında mevcut lokasyonlar elde edilir

    //    // Uygulamaya ait veritabanında mevcut lokasyonlar elde edilir:
    //    var current_locations = new List<string>();

    //    using (var conn = new SqlConnection(ConnectionString))
    //    {
    //        if (conn.State == ConnectionState.Closed)
    //            conn.Open();

    //        var cmd = new SqlCommand("SELECT Name FROM Locations", conn);

    //        var reader = cmd.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            current_locations.Add(reader.GetString(0));
    //        }
    //    }

    //    #endregion

    //    #region Active Directory'de yer alan güncel lokasyonlar elde edilir

    //    // Active Directory'de yer alan güncel lokasyonlar elde edilir:
    //    var locations = new List<string>();

    //    string adPathAgents = String.Empty;
    //    string adUsername = String.Empty;
    //    string adPassword = String.Empty;

    //    using (var conn = new SqlConnection(ConnectionString))
    //    {
    //        if (conn.State == ConnectionState.Closed)
    //            conn.Open();

    //        var cmd = new SqlCommand("SELECT TOP (1) * FROM Settings", conn);

    //        var reader = cmd.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            adUsername = reader.GetString(0);
    //            adPassword = reader.GetString(1);
    //            adPathAgents = reader.GetString(2);
    //        }
    //    }

    //    DirectorySearcher adSearcher = new DirectorySearcher(
    //        new DirectoryEntry(adPathAgents, adUsername, adPassword), "objectClass=organizationalUnit",
    //        new string[] { "name" }, SearchScope.OneLevel);

    //    SearchResultCollection searchResult = adSearcher.FindAll();

    //    for (int i = 0; i < searchResult.Count; i++)
    //    {
    //        string location = searchResult[i].Properties["name"][0].ToString();
    //        locations.Add(location);
    //    }

    //    #endregion

    //    #region Active Directory'de olup, veritabanında olmayan lokasyonlar tespit edilip, tablo olarak SQL'e gönderilir

    //    // Active Directory'de olup, veritabanında olmayan lokasyonlar tespit edilip, tablo olarak SQL'e gönderilir:
    //    SqlDataRecord table = new SqlDataRecord(new SqlMetaData[]{
    //        new SqlMetaData("Name", SqlDbType.NVarChar, 50)
    //    });

    //    SqlContext.Pipe.SendResultsStart(table);
    //    {
    //        foreach (string location in locations)
    //        {
    //            // Eğer ilgili lokasyon veritabanında mevcutsa, bir sonraki lokasyona atla:
    //            if (current_locations.Contains(location))
    //                continue;

    //            table.SetSqlString(0, location);

    //            SqlContext.Pipe.SendResultsRow(table);
    //        }
    //    }

    //    SqlContext.Pipe.SendResultsEnd();

    //    #endregion
    //}

    //[Microsoft.SqlServer.Server.SqlProcedure]
    //public static void ActiveDirectorySyncUsers()
    //{
    //    #region Uygulamaya ait veritabanında mevcut kullanıcılar elde edilir

    //    // Uygulamaya ait veritabanında mevcut kullanıcılar elde edilir:
    //    var current_users = new List<string>();

    //    using (var conn = new SqlConnection(ConnectionString))
    //    {
    //        if (conn.State == ConnectionState.Closed)
    //            conn.Open();

    //        var cmd = new SqlCommand("SELECT LoginId FROM Agents", conn);

    //        var reader = cmd.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            current_users.Add(reader.GetString(0));
    //        }
    //    }

    //    #endregion

    //    #region Active Directory'de yer alan güncel kullanıcılar elde edilir

    //    // Active Directory'de yer alan güncel kullanıcılar elde edilir:
    //    var users = new List<Tuple<string, string, string, string>>();

    //    string adPathSupervisors = String.Empty;
    //    string adPathAgents = String.Empty;
    //    string adUsername = String.Empty;
    //    string adPassword = String.Empty;

    //    using (var conn = new SqlConnection(ConnectionString))
    //    {
    //        if (conn.State == ConnectionState.Closed)
    //            conn.Open();

    //        var cmd = new SqlCommand("SELECT TOP (1) * FROM Settings", conn);

    //        var reader = cmd.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            adUsername = reader.GetString(0);
    //            adPassword = reader.GetString(1);
    //            adPathAgents = reader.GetString(2);
    //            adPathSupervisors = reader.GetString(3);
    //        }
    //    }

    //    string[] paths = new string[] { adPathAgents, adPathSupervisors };

    //    foreach (var adPath in paths)
    //    {
    //        DirectorySearcher adSearcher = new DirectorySearcher(
    //       new DirectoryEntry(adPath, adUsername, adPassword), "objectClass=user",
    //       new string[] { "sn", "givenName", "sAMAccountName", "ipPhone" }, SearchScope.Subtree);

    //        adSearcher.PageSize = 10000;

    //        SearchResultCollection searchResult = adSearcher.FindAll();

    //        for (int i = 0; i < searchResult.Count; i++)
    //        {
    //            if (!(searchResult[i].Properties["sAMAccountName"].Count > 0) || !(searchResult[i].Properties["givenName"].Count > 0) || !(searchResult[i].Properties["sn"].Count > 0) || !(searchResult[i].Properties["ipPhone"].Count > 0))
    //                continue;

    //            string loginId = searchResult[i].Properties["sAMAccountName"][0].ToString();
    //            string firstName = searchResult[i].Properties["givenName"][0].ToString();
    //            string lastName = searchResult[i].Properties["sn"][0].ToString();
    //            string ipPhone = searchResult[i].Properties["ipPhone"][0].ToString();

    //            if (loginId.Contains("test") || firstName.Contains("test") || lastName.Contains("test"))
    //                continue;

    //            var exists = users.Find(x => x.Item1 == loginId);
    //            if (exists != null)
    //                continue;

    //            users.Add(new Tuple<string, string, string, string>(loginId, firstName, lastName, ipPhone));
    //        }
    //    }

    //    users.Sort((x, y) => x.Item1.CompareTo(y.Item1));

    //    #endregion

    //    #region Active Directory'de olup, veritabanında olmayan kullanıcılar tespit edilip, tablo olarak SQL'e gönderilir

    //    // Active Directory'de olup, veritabanında olmayan kullanıcılar tespit edilip, tablo olarak SQL'e gönderilir:
    //    SqlDataRecord table = new SqlDataRecord(new SqlMetaData[]{
    //        new SqlMetaData("LoginId", SqlDbType.Char, 7),
    //        new SqlMetaData("AgentTypeId", SqlDbType.Int),
    //        new SqlMetaData("FirstName", SqlDbType.NVarChar, 50),
    //        new SqlMetaData("LastName", SqlDbType.NVarChar, 50),
    //        new SqlMetaData("IpPhone", SqlDbType.Char, 6)
    //    });

    //    SqlContext.Pipe.SendResultsStart(table);
    //    {
    //        foreach (Tuple<string, string, string, string> user in users)
    //        {
    //            // Eğer ilgili kullanıcı veritabanında mevcutsa, bir sonraki kullanıcıya atla:
    //            if (current_users.Contains(user.Item1))
    //                continue;

    //            table.SetSqlString(0, user.Item1);
    //            table.SetSqlInt32(1, 5);
    //            table.SetSqlString(2, user.Item2);
    //            table.SetSqlString(3, user.Item3);
    //            table.SetSqlString(4, user.Item4);

    //            SqlContext.Pipe.SendResultsRow(table);
    //        }
    //    }

    //    SqlContext.Pipe.SendResultsEnd();

    //    #endregion
    //}
}
