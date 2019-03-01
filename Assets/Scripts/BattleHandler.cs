using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        float outcome = 1;

        // Your code between here
   
        // Variable for rhythm and style stats
        int statsPlayer = data.player.rhythm + data.player.style;
        int statsNpc = data.npc.rhythm + data.npc.style;

        int playerRand = 4;
        int npcRand = 4;

        // Get a random variable to multiply luck by
        float npcLuckPercentage = data.npc.luck * Random.Range(1, playerRand);
        float playerLuckPercentage = data.player.luck * Random.Range(1, npcRand);

        //Multiply stats by random luck variable multiplier and compare
        if (statsPlayer * playerLuckPercentage >= statsNpc * npcLuckPercentage)
        {
            outcome = 1;
            Debug.Log("Player wins!");
        }
        else
        {
            outcome = 0;
            Debug.Log("Player loses!");
        }

        //Level of player cap luck multiplier increase
        if (data.player.level >= 5)
        {
            playerRand++;
        }
        else if (data.player.level >= 10)
        {
            playerRand++;
        }

        //Level of npc cap luck multiplier increases
        if (data.npc.level >= 5)
        {
            npcRand++;
        }
        else if (data.npc.level >= 10)
        {
            npcRand++;
        }

        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);


        //-------------------------------------------------------
        /*
        Debug.Log(data.npc.rhythm);
        Debug.Log(data.npc.style);
        Debug.Log(data.npc.luck);

        Debug.Log(data.player.rhythm);
        Debug.Log(data.player.style);
        Debug.Log(data.player.luck);
        */

        // Set outcome to 0 if the player lost
        // Set outcome to 1 if the player won

        // and here
        //--------------------------------------------------------
    }
}
