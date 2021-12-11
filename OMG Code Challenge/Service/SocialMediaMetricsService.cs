using Newtonsoft.Json;
using OMG_Code_Challenge.Common.CommonHelpers;
using OMG_Code_Challenge.Common.CustomeResponse;
using OMG_Code_Challenge.IService;
using OMG_Code_Challenge.Model.Data_Transfer_Object;
using OMG_Code_Challenge.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Service
{
    public class SocialMediaMetricsService : ISocialMediaMetricsService
    {
        public dynamic PullsMedia(dynamic pullsMediaDTO)
        {
            List<string> response = new List<string>();
            SocialMediaIntegration facebookIntegration;
            SocialMediaIntegration googleIntegration;
            SocialMediaIntegration twitterIntegration;
            SocialMediaIntegration tikTokIntegration;


            var pullsMediaObj = JsonConvert.DeserializeObject(pullsMediaDTO.GetRawText());

            if (pullsMediaObj["FacebookDTO"] != null)
            {
                FacebookDTO facebookDTO= OMGJsonConvert<FacebookDTO>.DeserializeObject(pullsMediaObj["FacebookDTO"]);
   

                facebookIntegration = new FacebookIntegration();

                string pulls = facebookIntegration.PullsMedia(facebookDTO);

                response.Add(pulls);
              
            }

           if (pullsMediaObj["GoogleDTO"] != null)
            {
                GoogleDTO googleDTO= OMGJsonConvert<GoogleDTO>.DeserializeObject(pullsMediaObj["GoogleDTO"]);

                googleIntegration = new GoogleIntegration();

                string pulls = googleIntegration.PullsMedia(googleDTO);

                response.Add(pulls);
            }

            if (pullsMediaObj["TwitterDTO"] != null)
            {
                TwitterDTO twitterDTO = OMGJsonConvert<TwitterDTO>.DeserializeObject(pullsMediaObj["TwitterDTO"]);

                twitterIntegration = new TwitterIntegration();

                string pulls = twitterIntegration.PullsMedia(twitterDTO);

                response.Add(pulls);
            }

            if (pullsMediaObj["TikTokDTO"] != null)
            {

                TikTokDTO tikTokDTO = OMGJsonConvert<TikTokDTO>.DeserializeObject(pullsMediaObj["TikTokDTO"]); ;

                tikTokIntegration = new TikTokIntegration();

                string pulls = tikTokIntegration.PullsMedia(tikTokDTO);

                response.Add(pulls);
            }
        

            return response;

        }
    }
}
