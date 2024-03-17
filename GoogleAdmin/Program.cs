using System;
using System.Collections.Generic;
using System.CommandLine;
using Google.Apis.Auth.OAuth2;
using GoogleAdmin.Logic;
using GoogleAdmin.Models;
using static GoogleAdmin.Models.GoogleAdminConstants;

var businessOption = new Option<BusinessType>(name: "--business", description: "Business options: HP or AE");

RootCommand? rootCommand = new RootCommand("Synchronize signatures for HP or AE.");
rootCommand.AddOption(businessOption);

rootCommand.SetHandler(async (selection) =>
{
    var business = Settings[selection];

    await GoogleCredentialAuth.ReadClientJson(business.JsonFileName);
    var googleCreds = GoogleCredentialAuth.GetAdminServiceCredentials(business.AdminUserName);

    var gas = new GoogleAdminSupport(googleCreds, business.ApplicationName);
    IEnumerable<GoogleUser> users = await gas.GetUsers();

    var gms = new GmailSupport(business.ApplicationName);
    await gms.SetSignature(users, business.Signature);

}, businessOption);

await rootCommand.InvokeAsync(args);