using System;
using System.Collections.Generic;
using System.CommandLine;
using Google.Apis.Auth.OAuth2;
using GoogleAdmin.Logic;
using GoogleAdmin.Models;
using static GoogleAdmin.Models.GoogleAdminConstants;

var businessOption = new Option<BusinessType>(name: "--business", description: "Business options: HP or AE");
var dryRunOption = new Option<bool>(name: "--dry-run", description: "Dry run mode") { IsRequired = false };

RootCommand? rootCommand = new RootCommand("Synchronize signatures for HP or AE.");
rootCommand.AddOption(businessOption);
rootCommand.AddOption(dryRunOption);

rootCommand.SetHandler(async (selection, dryRunOption) =>
{
    var business = Settings[selection];

    await GoogleCredentialAuth.ReadClientJson(business.JsonFileName);
    var googleCreds = GoogleCredentialAuth.GetAdminServiceCredentials(business.AdminUserName);

    var gas = new GoogleAdminSupport(googleCreds, business.ApplicationName);
    IEnumerable<GoogleUser> users = await gas.GetUsers();

    var gms = new GmailSupport(business.ApplicationName, dryRunOption);
    await gms.SetSignature(users, business.Signature);

}, businessOption, dryRunOption);

await rootCommand.InvokeAsync(args);