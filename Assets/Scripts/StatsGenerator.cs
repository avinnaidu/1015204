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
        stats.rhythm = 23422;
        stats.luck = 5;
        stats.style = 5;
    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {
        Debug.Log("why does this run but everyting e4lse not urn i dont uansdonfadsf");
        Debug.Log(stats.rhythm);
        Debug.Log(stats.style);
        Debug.Log(stats.luck);
        Debug.Log("Craketty crackett");
    }
}
