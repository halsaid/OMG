using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.Model.Data_Transfer_Object
{
    public class SocialMediaDTO
    {
        public FacebookDTO FacebookDTO { get; set; }
        public GoogleDTO GoogleDTO { get; set; }
        public TwitterDTO TwitterDTO { get; set; }
        public TikTokDTO TikTokDTO { get; set; }
    }
}
