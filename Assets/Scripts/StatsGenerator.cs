using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{
    public static void InitialStats(Stats stats)
    {
        // all characters start at level 1
        stats.level = 1;

        // start at 0 experience points
        stats.xp = 0;

        // For you todo - set the stats
        stats.rhythm = 1;
        stats.style = 10; 
        stats.luck = 5;
      

        Debug.Log("Your characters rhythm stat is currently at " + stats.rhythm);
        Debug.Log("Your characters style stat is currently at " + stats.style);
        Debug.Log("Your characters luck stat is currently at " + stats.luck);
    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {
        // When player levels up, this function will add 10 stats to rhythm, style and luck.
        while (points >= 1)
        {
            stats.rhythm++;
            stats.style++;
            stats.luck++;
            points--;
        }

        Debug.Log("Your characters rhythm stat is currently at " + stats.rhythm);
        Debug.Log("Your characters style stat is currently at " + stats.style);
        Debug.Log("Your characters luck stat is currently at " + stats.luck);

    }
}
