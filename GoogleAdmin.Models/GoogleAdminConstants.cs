using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAdmin.Models;

public static class GoogleAdminConstants
{
    public static readonly ImmutableDictionary<BusinessType, Business> Settings = new Dictionary<BusinessType, Business>()
    {
        { 
            BusinessType.HP, 
            new Business("Hire Police Signatures", "hirepoliceSA.json", "admin@hirepolice.com", "{0}<br>{1}<br><img src=\"https://lh4.googleusercontent.com/rbPPIKLbpy4Lyh6mHaTWuwoFwxaNMA-MAO20zkfP8DjRBfKrYMyNM-37MaKId1_hRGOEu82ITMXWOlqp4-K5ZV0VadYrmXOCCajohB2aFR-32kJGcmg-J1ukKfbZh5qThNl4BlKj\" style=\"margin-top:0px\" class=\"CToWUd\" width=\"217.97260273972603\" height=\"87\"><br>After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br>215-302-7977 • PA  / 702 N. 3rd Street #40, Philadelphia, PA 19123 <br>410-656-2221 • MD / 8480 Baltimore National Pike #181 Ellicott City, MD 21043<br>202-280-1772 • DC / 100 M St SE #600, Washington, DC 20003<br>757-250-5729 • VA & NC / 780 Lynnhaven Parkway / Suite 400 Virginia Beach, VA 23452<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br>") 
        },
        { 
            BusinessType.AE, 
            new Business("Armed Enforcement Signatures", "armedEnforcementSA.json", "admin@armedenforcement.com", "{0}<br>{1}<br><img src=\"https://lh4.googleusercontent.com/rbPPIKLbpy4Lyh6mHaTWuwoFwxaNMA-MAO20zkfP8DjRBfKrYMyNM-37MaKId1_hRGOEu82ITMXWOlqp4-K5ZV0VadYrmXOCCajohB2aFR-32kJGcmg-J1ukKfbZh5qThNl4BlKj\" style=\"margin-top:0px\" class=\"CToWUd\" width=\"217.97260273972603\" height=\"87\"><br>Armed Enforcement Test After Hours Client Call Center<br>(503) 207-5300 - For use between 8 PM - 8 AM Daily<br><br>215-302-7977 • PA  / 702 N. 3rd Street #40, Philadelphia, PA 19123 <br>410-656-2221 • MD / 8480 Baltimore National Pike #181 Ellicott City, MD 21043<br>202-280-1772 • DC / 100 M St SE #600, Washington, DC 20003<br>757-250-5729 • VA & NC / 780 Lynnhaven Parkway / Suite 400 Virginia Beach, VA 23452<br>305-421-7266 • FL / 2598 E Sunrise Blvd Suite 2104 Fort Lauderdale, FL 33304<br>")
        }
    }.ToImmutableDictionary();
}

