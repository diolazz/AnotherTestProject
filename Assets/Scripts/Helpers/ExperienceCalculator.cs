using System;
using System.Collections.Generic;
using UnityEngine;

public static class ExperienceCalculator
{
    private static int[] xpTargets = new int[] { 0, 7, 15, 29, 52, 78, 114, 154, 214, 278, 352, 440, 540, 660, 790, 945, 1110, 1310, 1520, 1750, 2030, 2330, 2665, 3030, 3340, 3890, 4380, 4930, 5530, 6190, 6915, 7700, 8550, 9430, 10370, 11370, 12430, 13560, 14740, 16000, 17345, 18750, 20260, 21860, 23500 };

    public static int GetLevel(int exp)
    {
        for (int i = 0; i < xpTargets.Length - 1; i++)
        { 
            if (exp == xpTargets[i] || (exp > xpTargets[i] && exp < xpTargets[i + 1]))
            {
                return (i + 1); 
            }
        }

        return xpTargets.Length;
    }

    public static float GetPercentInToLevel(int level, int exp)
    {
        if (level == xpTargets.Length)
        {
            return 1f;
        }

        int xpInToLevel = exp - xpTargets[level - 1];
        int xpTopEnd = xpTargets[level] - xpTargets[level - 1];

        return  (float)xpInToLevel / (float)xpTopEnd;
    }
}