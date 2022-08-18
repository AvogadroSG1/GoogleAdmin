using System;
using System.Collections.Generic;
using System.CommandLine;
using Google.Apis.Auth.OAuth2;
using GoogleAdmin.Logic;
using GoogleAdmin.Models;
using static GoogleAdmin.Models.GoogleAdminConstants;

var businessOption = new Option<Business>(name: "--business", description: "Business options: HP or AE");

var rootCommand = new RootCommand("Synchronize signatures for HP or AE.");
rootCommand.AddOption(businessOption);

rootCommand.SetHandler(async (business) =>
{
    GoogleCredential googleCreds = GoogleCredentialAuth.GetAdminServiceCredentials();

    GoogleAdminSupport gas = new GoogleAdminSupport(googleCreds);
    List<GoogleUser> users = await gas.GetUsers();

    GmailSupport gms = new GmailSupport();
    await gms.SetSignature(users);
});

