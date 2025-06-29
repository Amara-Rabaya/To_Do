﻿using Tranning_pro.Constants;

namespace Tranning_pro.Helper
{
    public static class cityRankHelper
    {
      
        
            public static int? Calculate(int? population)
            {
                if (population == null)
                    return null;

                if (population > 20000)
                    return Constant.rankCon.Golde;
                else if (population > 10000)
                    return Constant.rankCon.Silver;
                else if (population > 10000)
                    return Constant.rankCon.Bronze;
                else
                    return 0;
            }
        
    }
}
