using System.Collections.Generic;
using System.Collections.Immutable;

namespace GoogleAdmin.Models;

public static class GoogleAdminConstants
{
    public enum CostCenter
    {
        Admin = 1,
        HP = 2,
        AE = 3
    }

    public static readonly ImmutableDictionary<CostCenter, string> SignatureSet = new Dictionary<CostCenter, string>()
    {
        {
            CostCenter.HP,
            "{0}<br>{1}<br><img alt=\"Image of a police badge with HirePolice in the middle\" src=\"https://lh3.googleusercontent.com/pw/AL9nZEV_laI7POyfLgA4OShuayijzZlxUJOxqtPpTigzFhNVUWEd5FKSHtmsvzbpfUsYM44LXpv3yN_NBO58-sy1HfP1Mon-dkDQu5Kiz3SsQ3sH_lNDdfp2z_bN9fYG8O7YP49zRKfCs-s4i-yKKDW15Mg=w1091-h1279-no?authuser=4\" style=\"margin-top:0px\" class=\"CToWUd\" width=\"55\" height=\"65\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br><a href=\"http://www.hirepolice.com/\" hspace=\"streak-track\" rel=\"noopener\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=http://www.hirepolice.com/&amp;source=gmail&amp;ust=1668125337597000&amp;usg=AOvVaw32ZatacPVadPjmWfnyrqP4\">www.hirepolice.com</a><br><br>215-302-7977 • PA / 702 N. 3rd Street #40, Philadelphia, PA 19123<br>410-656-2221 • MD / 8480 Baltimore National Pike #181 Ellicott City, MD 21043<br>202-280-1772 • DC / 100 M St SE #600, Washington, DC 20003<br><br>PA License #000324-2020 <br>MD License #106-4928 <br>DC License #SAB29392 <br><br><span style=\"color:rgb(0,0,0);font-family:Arial;font-size:11px;font-style:italic\">Legal Notice: &nbsp;This message is intended for the addressee(s) only and, unless expressly stated otherwise, is confidential and may be privileged.&nbsp; If you are not an addressee, (i) please inform the sender immediately and permanently delete and destroy the original and any copies or printouts of this message, and (ii) be advised that any disclosure, copying or use of the information in this message is unauthorized and may be unlawful.</span> <br>"
        },
        {
            CostCenter.AE,
            "{0}<br>{1}<br><img alt=\"Image of a circle with Armed Enforcement in the middle\" src=\"https://lh3.googleusercontent.com/pw/AL9nZEVGep2LuPo7J1Qz1sIwlrosfYSvNsfuvUa1T3NlkiAljQ1r8mT_W5FM0zs4Vtzpp0YNeXj-lit_xGuv1VBuM_yjYMJeOvGpLGVMMa1Ag1r7sr5nCNVNxxEy2xZAXJUWA9UwpYdIsBHAlmQs6wbeNI4=w305-h288-no?authuser=4\" style=\"margin-top:0px\" class=\"CToWUd\" width=\"75\" height=\"65\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br><a href=\"http://www.armedenforcement.com/\" hspace=\"streak-track\" rel=\"noopener\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=http://www.armedenforcement.com/&amp;source=gmail&amp;ust=1668125337598000&amp;usg=AOvVaw1G2zZTF0Xs0GBM0G5qsqRW\">www.armedenforcement.com</a><br><br> 757-250-5729 • NC / 5960 Fairview Rd. Suite 400 Charlotte, NC 28210<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br> <br>VA License #11-16037 <br>FL License #B-1800280 <br>NC License #932336-GP / BPN 959090M <br>SC License #3902 <br><br><span style=\"color:rgb(0,0,0);font-family:Arial;font-size:11px;font-style:italic\">Legal Notice: &nbsp;This message is intended for the addressee(s) only and, unless expressly stated otherwise, is confidential and may be privileged.&nbsp; If you are not an addressee, (i) please inform the sender immediately and permanently delete and destroy the original and any copies or printouts of this message, and (ii) be advised that any disclosure, copying or use of the information in this message is unauthorized and may be unlawful.</span> <br>"
        }
    }.ToImmutableDictionary();

    public static readonly ImmutableDictionary<BusinessType, Business> Settings = new Dictionary<BusinessType, Business>()
    {
        {
            BusinessType.HP,
            new Business(
                "Hire Police Signatures",
                "hirepoliceSA.json",
                "admin@hirepolice.com",
                SignatureSet[CostCenter.HP]
                )
        },
        {
            BusinessType.AE,
            new Business(
                "Armed Enforcement Signatures",
                "armedEnforcementSA.json",
                "admin@armedenforcement.com",
                SignatureSet[CostCenter.AE]
                )
        }
    }.ToImmutableDictionary();
}
