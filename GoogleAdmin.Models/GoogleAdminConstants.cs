using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace GoogleAdmin.Models;

public static class GoogleAdminConstants
{
    public static readonly ImmutableDictionary<BusinessType, Business> Settings = new Dictionary<BusinessType, Business>()
    {
        { 
            BusinessType.HP, 
            new Business(
                "Hire Police Signatures", 
                "hirepoliceSA.json", 
                "admin@hirepolice.com",
                "{0}<br>{1}<br><img src=\"https://lh3.googleusercontent.com/pw/AL9nZEV_laI7POyfLgA4OShuayijzZlxUJOxqtPpTigzFhNVUWEd5FKSHtmsvzbpfUsYM44LXpv3yN_NBO58-sy1HfP1Mon-dkDQu5Kiz3SsQ3sH_lNDdfp2z_bN9fYG8O7YP49zRKfCs-s4i-yKKDW15Mg=w1091-h1279-no?authuser=4\"style=\"margin-top:0px\" class=\"CToWUd\" width=\"55\" height=\"65\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br>215-302-7977 • PA / 702 N. 3rd Street #40, Philadelphia, PA 19123<br>410-656-2221 • MD / 8480 Baltimore National Pike #181 Ellicott City, MD 21043<br>202-280-1772 • DC / 100 M St SE #600, Washington, DC 20003<br>",
                "{0}<br>{1}<br><img src=\"https://lh3.googleusercontent.com/pw/AL9nZEXh-JvNmtmkkd94KpFHFNJjZrMrXYQkgMeRAUD_i_AI4lqRPxKDxVM9x6-HXiUPIoN5fdzaKMELZrmKDJwsiL79CBzvNU8RLHDWxdG-fWYCcMnUs5lXF_Nlbko1ridZxfi0wAF2gTYCo4wxLrL7VKw=w673-h288-no?authuser=0\"style=\"margin-top:0px\" class=\"CToWUd\" width=\"217.97260273972603\" height=\"87\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br>215-302-7977 • PA / 702 N. 3rd Street #40, Philadelphia, PA 19123<br>410-656-2221 • MD / 8480 Baltimore National Pike #181 Ellicott City, MD 21043<br>202-280-1772 • DC / 100 M St SE #600, Washington, DC 20003<br>757-250-5729 • VA & NC / 780 Lynnhaven Parkway / Suite 400 Virginia Beach, VA 23452<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br>"
                )
        },
        { 
            BusinessType.AE, 
            new Business(
                "Armed Enforcement Signatures", 
                "armedEnforcementSA.json", 
                "admin@armedenforcement.com",
                "{0}<br>{1}<br><img src=\"https://lh3.googleusercontent.com/pw/AL9nZEVGep2LuPo7J1Qz1sIwlrosfYSvNsfuvUa1T3NlkiAljQ1r8mT_W5FM0zs4Vtzpp0YNeXj-lit_xGuv1VBuM_yjYMJeOvGpLGVMMa1Ag1r7sr5nCNVNxxEy2xZAXJUWA9UwpYdIsBHAlmQs6wbeNI4=w305-h288-no?authuser=4\"style=\"margin-top:0px\" class=\"CToWUd\" width=\"109\" height=\"100\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br>757-250-5729 • VA & NC / 780 Lynnhaven Parkway / Suite 400 Virginia Beach, VA 23452<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br>"
                )
        }
    }.ToImmutableDictionary();
}
