using OMG_Code_Challenge.Common.CustomeResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.IService
{
    public interface ISocialMediaMetricsService
    {
        dynamic PullsMedia(dynamic pullsMediaDTO);
    }
}
