using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using GoogleAdmin.Logic;
using GoogleAdmin.Models;

namespace GoogleAdmin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GoogleCredential googleCreds = await GoogleCredentialAuth.GetAdminServiceCredentials();

            GoogleAdminSupport gas = new GoogleAdminSupport(googleCreds);
            List<GoogleUser> users = await gas.GetUsers();

            GmailSupport gms = new GmailSupport();
            await gms.SetSignature(users);
        }
    }
}
