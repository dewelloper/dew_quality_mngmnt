using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class MessageHelper
    {
        public static class MessageType
        {
            /// <summary>
            /// Geriye "Bilgi" deÄŸerini dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            public const string Information = "Bilgi";

            /// <summary>
            /// Geriye "UyarÄ±" deÄŸerini dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            public const string Warning = "UyarÄ±";

            /// <summary>
            /// Geriye "Hata" deÄŸerini dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            public const string Error = "Hata";
        }

        public static class MessageTitle
        {
            /// <summary>
            /// Geriye "Ä°ÅŸlem BaÅŸarÄ±lÄ±!" mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            public const string Success = "Ä°ÅŸlem BaÅŸarÄ±lÄ±!";

            /// <summary>
            /// Geriye "UyarÄ±!" mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            public const string Warning = "UyarÄ±!";

            /// <summary>
            /// Geriye "Ä°ÅŸlem BaÅŸarÄ±sÄ±z!" mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            public const string Error = "Ä°ÅŸlem BaÅŸarÄ±sÄ±z!";
        }

        public static class CRUDMessage
        {
            /// <summary>
            /// Geriye "Obje baÅŸarÄ±yla kaydedildi." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string SuccessInsert(string data)
            {
                return String.Format("{0} baÅŸarÄ±yla kaydedildi.", data);
            }

            /// <summary>
            /// Geriye "Obje baÅŸarÄ±yla gÃ¼ncellendi." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string SuccessUpdate(string data)
            {
                return String.Format("{0} baÅŸarÄ±yla gÃ¼ncellendi.", data);
            }

            /// <summary>
            /// Geriye "Obje baÅŸarÄ±yla silindi." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string SuccessDelete(string data)
            {
                return String.Format("{0} baÅŸarÄ±yla silindi.", data);
            }

            /// <summary>
            /// Geriye "Obje kaydedilirken bir hata oluÅŸtu." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string ErrorInsert(string data)
            {
                return String.Format("{0} kaydedilirken bir hata oluÅŸtu.", data);
            }

            /// <summary>
            /// Geriye "Obje gÃ¼ncellenirken bir hata oluÅŸtu." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string ErrorUpdate(string data)
            {
                return String.Format("{0} gÃ¼ncellenirken bir hata oluÅŸtu.", data);
            }

            /// <summary>
            /// Geriye "Obje silinirken bir hata oluÅŸtu." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string ErrorDelete(string data)
            {
                return String.Format("{0} silinirken bir hata oluÅŸtu", data);
            }

            /// <summary>
            /// Geriye "Obje listesi yÃ¼klenirken bir hata oluÅŸtu." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string ErrorRetrieveList(string data)
            {
                return String.Format("{0} listesi yÃ¼klenirken bir hata oluÅŸtu.", data);
            }

            /// <summary>
            /// Geriye "Obje bilgileri yÃ¼klenirken bir hata oluÅŸtu." mesajÄ±nÄ± dÃ¶ndÃ¼rÃ¼r.
            /// </summary>
            /// <param name="data">Obje adÄ± (MÃ¼ÅŸteri Temsilcisi, Ã‡aÄŸrÄ±, Soru vb.)</param>
            /// <returns>Ä°ÅŸlem sonucunun mesajÄ±</returns>
            public static string ErrorRetrieveSingle(string data)
            {
                return String.Format("{0} bilgileri getirilirken bir hata oluÅŸtu.", data);
            }

            public static string UserTransferedSuccess(string data)
            {
                return String.Format("{0} Transfer iÅŸlemi baÅŸarÄ± ile tamamlandÄ±.", data);
            }

            public static string UserTransferedUnSuccess(string data)
            {
                return String.Format("{0} Transfer iÅŸlemi yapmak iÃ§in Admin veya Kalite uzmanÄ± olmanÄ±z gerekmektedir.", data);
            }

            public static string IPPhoneValidation(string data)
            {
                return String.Format("{0} IPPhone alanÄ± en fazla 6 karakter ve nÃ¼merik olmalÄ±dÄ±r.", data);
            }
        }

        public static class LoginMessage
        {
            public const string InvalidUsernamePassword = "KullanÄ±cÄ± adÄ± / ÅŸifre hatalÄ±. LÃ¼tfen tekrar deneyiniz.";
            public const string DisabledAccount = "GiriÅŸ yapmaya Ã§alÄ±ÅŸtÄ±ÄŸÄ±nÄ±z hesap kilitlenmiÅŸtir. LÃ¼tfen birim yÃ¶neticinize baÅŸvurunuz.";
        }
    }
}
