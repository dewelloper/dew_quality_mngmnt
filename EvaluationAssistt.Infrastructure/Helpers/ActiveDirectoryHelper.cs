using System;
using System.Collections.Generic;
using System.Linq;
using System.DirectoryServices;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class ActiveDirectoryHelper
    {
        private readonly string adPathAgents;
        private readonly string adPathSupervisors;
        private readonly string adPathRoot;
        private readonly string adUsername;
        private readonly string adPassword;

        public ActiveDirectoryHelper()
        {
            var settings = WebConfigurationManager.AppSettings;

            adPathAgents = settings["adPathAgents"];
            adPathSupervisors = settings["adPathSupervisors"];
            adPathRoot = settings["adPathRoot"];
            adUsername = settings["adUsername"];
            adPassword = settings["adPassword"];
        }

        public bool UserExists(string username)
        {
            try
            {
                using (var de = new DirectoryEntry(adPathRoot, adUsername, adPassword))
                {
                    using (var adSearch = new DirectorySearcher(de))
                    {
                        adSearch.SearchScope = SearchScope.Subtree;
                        adSearch.Filter = String.Format("(sAMAccountName={0})", username);

                        var adSearchResult = adSearch.FindOne();

                        return adSearchResult != null;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AgentExists(string username)
        {
            try
            {
                using (var de = new DirectoryEntry(adPathRoot, adUsername, adPassword))
                {
                    using (var adSearch = new DirectorySearcher(de))
                    {
                        adSearch.SearchScope = SearchScope.Subtree;
                        adSearch.Filter = String.Format("(sAMAccountName={0})", username);

                        var adSearchResult = adSearch.FindOne();

                        return adSearchResult != null;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SupervisorExists(string username)
        {
            try
            {
                using (var de = new DirectoryEntry(adPathRoot, adUsername, adPassword))
                {
                    using (var adSearch = new DirectorySearcher(de))
                    {
                        adSearch.SearchScope = SearchScope.Subtree;
                        adSearch.Filter = String.Format("(sAMAccountName={0})", username);

                        var adSearchResult = adSearch.FindOne();

                        return adSearchResult != null;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public object GetUser()
        {
            try
            {
                using (var de = new DirectoryEntry(adPathAgents, adUsername, adPassword))
                {
                    using (var adSearch = new DirectorySearcher(de))
                    {
                        adSearch.Filter = String.Format("(sAMAccountName={0})", adUsername);

                        adSearch.PropertiesToLoad.Add("givenName");
                        adSearch.PropertiesToLoad.Add("sn");
                        adSearch.PropertiesToLoad.Add("displayName");
                        adSearch.PropertiesToLoad.Add("CN");
                        adSearch.PropertiesToLoad.Add("mail");
                        adSearch.PropertiesToLoad.Add("mobile");
                        adSearch.PropertiesToLoad.Add("department");

                        var adSearchResult = adSearch.FindOne();

                        dynamic user = new object();

                        user.FirstName = adSearchResult.Properties["givenName"][0].ToString();
                        user.LastName = adSearchResult.Properties["sn"][0].ToString();
                        user.DisplayName = adSearchResult.Properties["displayName"][0].ToString();
                        user.CommonName = adSearchResult.Properties["CN"][0].ToString();
                        user.Mail = adSearchResult.Properties["mail"][0].ToString();
                        user.Mobile = adSearchResult.Properties["mobile"][0].ToString();
                        user.Department = adSearchResult.Properties["department"][0].ToString();

                        return user;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public Dictionary<string, string> GetAllUsers()
        {
            var users = new Dictionary<string, string>();

            var adSearcher1 = new DirectorySearcher(new DirectoryEntry(adPathAgents, adUsername, adPassword), "objectClass=user", new string[] { "sn", "givenName", "sAMAccountName" }, SearchScope.Subtree);

            adSearcher1.SearchScope = SearchScope.Subtree;
            adSearcher1.PageSize = 10000;

            var searchResult1 = adSearcher1.FindAll();

            for (var i = 0; i < searchResult1.Count; i++)
            {
                if (searchResult1[i].Properties["sn"].Count > 0 && searchResult1[i].Properties["givenName"].Count > 0)
                {
                    var firstName = searchResult1[i].Properties["givenName"][0].ToString();
                    var lastName = searchResult1[i].Properties["sn"][0].ToString();

                    var username = String.Format("{0} {1}", firstName, lastName);
                    var accountName = searchResult1[i].Properties["sAMAccountName"][0].ToString();

                    if (!users.ContainsKey(accountName))
                    {
                        users.Add(accountName, String.Format("{0} - {1}", username, accountName));
                    }
                }
            }

            var sortedDict = (from entry in users
                                                 orderby entry.Value ascending
                                                 select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            return sortedDict;
        }

        public List<string> GetAllLocations()
        {
            var locations = new List<string>();

            var adSearcher = new DirectorySearcher(new DirectoryEntry(adPathAgents, adUsername, adPassword), "objectClass=organizationalUnit", new string[] { "name" }, SearchScope.OneLevel);

            var searchResult = adSearcher.FindAll();

            for (var i = 0; i < searchResult.Count; i++)
            {
                searchResult[i].Properties["name"][0].ToString();
            }

            return locations;
        }
    }
}
