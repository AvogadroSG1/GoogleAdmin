using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using GoogleAdmin.Models;

namespace GoogleAdmin.Logic
{
    public class GmailSupport
    {
        private string StandardSignature = "{0}<br>{1}<br><img src=\"https://lh4.googleusercontent.com/rbPPIKLbpy4Lyh6mHaTWuwoFwxaNMA-MAO20zkfP8DjRBfKrYMyNM-37MaKId1_hRGOEu82ITMXWOlqp4-K5ZV0VadYrmXOCCajohB2aFR-32kJGcmg-J1ukKfbZh5qThNl4BlKj\" style=\"margin-top:0px\" class=\"CToWUd\" width=\"217.97260273972603\" height=\"87\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br>215-302-7977 • PA  / 702 N. 3rd Street #40, Philadelphia, PA 19123 <br>410-656-2221 • MD / 8480 Baltimore National Pike #181 Ellicott City, MD 21043<br>202-280-1772 • DC / 100 M St SE #600, Washington, DC 20003<br>757-250-5729 • VA & NC / 780 Lynnhaven Parkway / Suite 400 Virginia Beach, VA 23452<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br>";
        private string ApplicationName = "Hire Police Signatures";
        private GmailService gmailService;
        private GoogleMailMessage googleMailMessage;

        public GmailSupport() { }

        public GmailSupport(GoogleCredential googleCreds)
        {
            this.gmailService = this.CreateGmailClient(googleCreds);
        }

        public GmailSupport(UserCredential credential)
        {
            this.gmailService = this.CreateGmailClient(credential);
        }

        public GmailSupport(UserCredential credential, GoogleMailMessage message)
        {
            this.googleMailMessage = message;
            this.gmailService = this.CreateGmailClient(credential);
        }

        private GmailService CreateGmailClient(GoogleCredential googleCreds)
        {
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCreds,
                ApplicationName = ApplicationName,
            });
        }

        private GmailService CreateGmailClient(UserCredential uc)
        {
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = uc,
                ApplicationName = ApplicationName,
            });
        }


        public void SetMessage(string emailAddress, string subject, string body)
        {
            this.googleMailMessage = new GoogleMailMessage()
            {
                EmailAddress = emailAddress,
                Subject = subject,
                Body = body
            };
        }

        public void SetMessage(GoogleMailMessage message)
        {
            this.googleMailMessage = message;
        }

        public async Task SendMail()
        {
            UsersResource.MessagesResource.SendRequest response = gmailService.Users.Messages.Send(this.googleMailMessage.GmailMessage, "me");

            Message test = await response.ExecuteAsync();
        }

        public async Task SetSignature(List<GoogleUser> users)
        {
            foreach(GoogleUser user in users)
            {
                gmailService = this.CreateGmailClient(await GoogleCredentialAuth.GetImpersonationServiceCredentials(user.PrimaryEmail));
                var signatureQuery = gmailService.Users.Settings.SendAs.List(user.User.Id);
                signatureQuery.Fields = "sendAs(isPrimary,sendAsEmail,signature)";
               
                var signatureResponse = await signatureQuery.ExecuteAsync();
                SendAs currentSendAs = signatureResponse.SendAs.SingleOrDefault(sa => sa.IsPrimary ?? false);
                currentSendAs.Signature = string.Format(this.StandardSignature, user.User.Name.FullName, user.User.Organizations[0]?.Title ?? string.Empty);
                currentSendAs = await gmailService.Users.Settings.SendAs.Patch(currentSendAs, user.User.Id, currentSendAs.SendAsEmail).ExecuteAsync();
                Console.WriteLine($"Updated {user.User.Name.FullName} -- {user.User.Organizations[0]?.Title ?? string.Empty}");
            }
        }
    }

    public class GoogleMailMessage
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Message GmailMessage
        {
            get
            {
                Message m = new Message();
                m.Raw = $"From: {this.EmailAddress}\r\nTo: {this.EmailAddress}\r\nSubject: {this.Subject}\r\n\r\n{this.Body}".EncodeBase64();
                return m;
            }
        }
    }


    public static class ExtensionMethods
    {
        public static string EncodeBase64(this string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }

        public static string DecodeBase64(this string value)
        {
            byte[] valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
    }
}
