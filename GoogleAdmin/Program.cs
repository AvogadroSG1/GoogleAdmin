using System;
using System.Collections.Generic;
using System.Linq;
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
            GoogleCredentialAuth auth = new GoogleCredentialAuth();
            UserCredential uc = await auth.GetCredentials();

            GoogleAdminSupport gas = new GoogleAdminSupport(uc);

            List<GoogleUser> users = await gas.GetUsers();

            users = users.Where(u => u.PrimaryEmail.Equals("admin@hirepolice.com")).ToList();

            GmailSupport gms = new GmailSupport();
        }
    }
}
