using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This handles all the battle logic of who is determined to be the winner of a fight between
/// two characters.
/// 
/// TODO:
///     - Battle needs to handle the logic for who wins a fight and telling the winner they get some XP for their trouble.
/// </summary>
public class BattleHandler:MonoBehaviour
{
    public SFXHandler sfxHandler; // reference to our sfx Handler to play sound effects.

    /// <summary>
    /// Is called when the player presses space bar.
    /// This function should take a player and npc 
    /// then determine who has won and give some xp and show some sweet winning effects.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="npc"></param>
    public void Battle(BriefManager player, BriefManager npc)
    {
        // Grab the player and NPC's power level and store them in here.
        int playerPowerLevel = BattleSystem.ReturnDancePowerLevel(player.statsSystem.style, player.statsSystem.rhythm, player.statsSystem.luck); // player powerlevel
        int npcPowerLevel = BattleSystem.ReturnDancePowerLevel(npc.statsSystem.style, npc.statsSystem.rhythm, npc.statsSystem.luck); ; // npc powerlevel
        
        if(playerPowerLevel <= 0 || npcPowerLevel <=0)
        {
            Debug.LogWarning("Player or NPC power level is 0, most likely the return dance power level logic has not be setup for this yet");
        }

        //TODO we probably want to comparBatte our powerlevels...hope they aren't over 9000.

        //TODO check if player wins, we probs wanna give them some xp
        
        //TODO finally if it's neither of the two above we must be a draw so maybe none get any xp.
        Debug.Log("Draw yo, need to git gud");
        SetWinningEffects(player, npc, 0); // // also if we want to show some winning effects 0 = draw, -1 = npc, 1 = player
        player.levellingSystem.AddXP(0); // player gets no xp
        npc.levellingSystem.AddXP(0); // npc gets no xp either
        

        // update the UI of both of characters
        npc.UpdateStatsUI();
        player.UpdateStatsUI();
    }

    #region No Modifications Required Section
    /// <summary>
    /// Is called at the begining of a fight, and sets the two characters to their dancing states.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="npc"></param>
    public void BeginBattlePhase(BriefManager player, BriefManager npc)
    {
        player.animController.Dance();
        npc.animController.Dance();
    }

    /// <summary>
    /// Takes in the player and npc stat scripts called at the end of the fight and sets the dancers states to either win, or lose state.
    /// 1 = player wins
    /// 0 = draw
    /// -1 = npc has won
    /// </summary>
    /// <param name="Player"></param>
    /// <param name="NPC"></param>
    /// <param name="outcome"></param>
    public void SetWinningEffects(BriefManager Player, BriefManager NPC, float BattleResult)
    {
        Player.animController.BattleResult(BattleResult);
        // give the npc the opposite of what ever the result is.
        NPC.animController.BattleResult(BattleResult * -1);
        // Play the appropriate sfx depending who won.
        sfxHandler.BattleResult(BattleResult);
    }
    #endregion
}
