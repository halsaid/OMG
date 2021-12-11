using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.SocialMedia
{
    public class FacebookIntegration : SocialMediaIntegration
    {
        public override dynamic PullsMedia(dynamic obj)
        {
            return "FacebookIntegration";
        }
    }
}
