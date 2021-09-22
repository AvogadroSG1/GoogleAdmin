using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleAdmin.Logic {
    public class GoogleCredentialAuth {
        static readonly string[] Scopes = { DirectoryService.Scope.AdminDirectoryUserReadonly, GmailService.Scope.GmailModify, GmailService.Scope.GmailSettingsBasic, GmailService.Scope.GmailCompose, GmailService.Scope.MailGoogleCom };

        public static async Task<UserCredential> GetCredentials (string email) {
            UserCredential credentials;

            using (var stream =
                new FileStream ("credentials.json", FileMode.Open, FileAccess.Read)) {
                string credPath = "token.json";
                credentials = GoogleWebAuthorizationBroker.AuthorizeAsync (
                    (await GoogleClientSecrets.FromStreamAsync (stream)).Secrets,
                    Scopes,
                    email,
                    CancellationToken.None,
                    new FileDataStore (credPath, true)).Result;
            }

            return credentials;
        }

        public static async Task<GoogleCredential> GetAdminServiceCredentials () {
            var decodedCreds = await GoogleCredential.FromFileAsync ("hirepoliceSA.json", CancellationToken.None);
            decodedCreds = decodedCreds.CreateScoped (Scopes);
            decodedCreds = decodedCreds.CreateWithUser ("admin@hirepolice.com");

            return decodedCreds;
        }

        public static async Task<GoogleCredential> GetImpersonationServiceCredentials (string user) {
            var decodedCreds = await GoogleCredential.FromFileAsync ("hirepoliceSA.json", CancellationToken.None);
            decodedCreds = decodedCreds.CreateScoped (Scopes);
            decodedCreds = decodedCreds.CreateWithUser (user);

            return decodedCreds;
        }
    }
}