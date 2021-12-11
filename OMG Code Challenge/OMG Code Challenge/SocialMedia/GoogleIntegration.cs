using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.SocialMedia
{
    public class GoogleIntegration : SocialMediaIntegration
    {
        public override dynamic PullsMedia(dynamic obj)
        {
            return "GoogleIntegration";
        }
    }
}
