using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds all the logic for our levelling system, so that includes logic to handle levelling up, gaining xp and detecting when we should level up!.
/// 
///TODO:
///     - Add XP needs to take the XP Gained, add it to our current xp, and detect if we need to call LevelUp().
///     - LevelUp needs to increase our current level, needs to increase our current xp threshold finally rather than 10 stats distributed, we want 10 for each level we are.
/// </summary>
public class LevellingSystem : MonoBehaviour
{
    public int curretLevel; // Our current level.

    public int currentXp; // The current amount of xp we have accumulated.

    public int currentXPThreshold = 10; // The amount of xp required to level up.

    #region setup variables, no mods needed
    private BriefManager briefManager; // reference to our stat system.
    private UIManager uiManager; // reference to our ui manager
    #endregion

    /// <summary>
    /// A function called when the battle is completed and some xp is to be awarded.
    /// The amount of xp gained is coming into this function
    /// </summary>
    public void AddXP(int xpGained)
    {
        // we probably want to do something with the xpGained.

        

        
        // displays xp on the ui if it exists
        if(uiManager != null && xpGained >0)
        {
            uiManager.ShowXpGainOnUI(xpGained, transform);
        }
    }

    /// <summary>
    /// A function used to handle actions associated with levelling up.
    /// </summary>
    private void LevelUp()
    {
        // TODO we probs want to increase our level....
        // TODO As well as probably want to increase our threshold for when we should level up...based on our current new level

        if(briefManager != null) // Do not delete.
        {
            briefManager.statsSystem.DistributePhysicalStatsOnLevelUp(10);
            briefManager.ShowLevelUpEffects();
        }
    }

    #region no mods required
    /// <summary>
    /// A method attached to a button that would allow us to check that our logic works as intentended
    /// No modification needed here, if your logic is sound you should be able to get expected values.
    /// </summary>
    public void TestImplementation()
    {
        int randomXp = Random.Range(0, 100);
        Debug.Log(string.Format("Current Xp: {0}; Xp Threshold: {1}; Current Level: {2}; XPGained: {3} ", currentXp, currentXPThreshold, curretLevel, randomXp));

        AddXP(randomXp);

        Debug.Log(string.Format("Current Xp: {0}; Xp Threshold: {1}; Current Level: {2}", currentXp, currentXPThreshold, curretLevel));

        if (briefManager != null)
        {
            Debug.Log(string.Format("Our new physical stats would be: str {0}, agil {1}, int {2}", briefManager.statsSystem.strength, briefManager.statsSystem.agility, briefManager.statsSystem.intelligence));
            Debug.Log(string.Format("Our new dancing stats would be: rhythm {0}, style {1}, luck {2}", briefManager.statsSystem.rhythm, briefManager.statsSystem.style, briefManager.statsSystem.luck));
        }
    }

    private void Start()
    {
        briefManager = GetComponent<BriefManager>();
        uiManager = FindObjectOfType<UIManager>();
    }
    #endregion
}
