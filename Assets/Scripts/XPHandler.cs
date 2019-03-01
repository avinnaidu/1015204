using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        // increments XP by every time player wins
        if (data.outcome > 0)
        {
            data.player.xp += 1; // add 1 xp to the player
        }

        // Checks the level of player and amount of XP needed to level up. 
        float xpReq = 0;

        if (data.player.level < 6)
        {
            xpReq = data.player.level + 2;
        }
        else if (data.player.level < 11)
        {
            xpReq = data.player.level + (data.player.level / 2);
        }
        else
        {
            xpReq = data.player.level * data.player.level;
        }

        //Compares current player xp to required xp to level, if it is met, player levels up, xp gets reset, and stats get assigned.
        if (data.player.xp >= xpReq)
        {
            GameEvents.PlayerLevelUp(data.player.level++);
            data.player.xp = 0;
            int numPoints = 10;
            StatsGenerator.AssignUnusedPoints(data.player, numPoints);
        }
        else
        {
            Debug.Log("The player is currently lvl " + data.player.level + " and needs an additional " + (xpReq - data.player.xp) + "XP to level up");
        }


        //-------------------------------------------------------------------------------------
        // check if the player leveled up
        // if they leveled up run this code - it makes NPCs level up

        // if player is within a level and exp range, they will lvl up and stats will be distributed
        /*
        if (data.player.level < 3 && data.player.xp >= 2)
        {
            Debug.Log("player level is = " + data.player.level);
            Debug.Log("npc level is = " + data.npc.level);      
            GameEvents.PlayerLevelUp(data.player.level++);
            Debug.Log("player level is now" + data.player.level);
            Debug.Log("npc level is = " + data.npc.level);
            int numPoints = 10;
            StatsGenerator.AssignUnusedPoints(data.player, numPoints);

            // data.player.xp = 0;
        }
        else if (data.player.level > 2 && data.player.level < 11 && data.player.xp >= 5)
        {
            Debug.Log("What now?....");
            Debug.Log("npc level is = " + data.npc.level);
            Debug.Log("player level is = " + data.player.level);
            Debug.Log("player xp is = " + data.player.xp);
            GameEvents.PlayerLevelUp(data.player.level++);
            data.player.xp = 0;
        }
        */

        // DON'T USE THIS CODE - makes player level 500
        // data.player.level = 500;
        //----------------------------------------------------------------------------------


    }
}
