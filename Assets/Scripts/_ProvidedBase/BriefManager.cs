using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class handles all the major logic for the main scene, mostly set up.
/// </summary>
public class BriefManager : MonoBehaviour
{
    public StatsSystem statsSystem;
    public LevellingSystem levellingSystem;
    public BattleSystem battleSystem;

    #region character references, no mods required
    [HideInInspector]
    public AnimationController animController; // reference to our animation controller on our character
    [HideInInspector]
    public SFXHandler sfxHandler; // reference to our sfx Handler in our scene
    [HideInInspector]
    public ParticleHandler particleHandler; // a refernce to our particle system that is played when we level up.  
    public UIManager uIManager; // a reference to the UI Manager in our scene.
    public StatsUI statsUI; // a referecence to our stats ui for this character.
    public GameObject xpUI;
    #endregion

    /// <summary>
    /// Called on the very first frame of the game
    /// </summary>
    private void Start()
    {
        //sets up the references to other scripts we need for functionality.
        SetUpReferences();
        // generate our stats.
        statsSystem.GeneratePhysicalStatsStats();
        statsSystem.CalculateDancingStats();

        UpdateStatsUI();
        SetPercentageToWin();
    }

    #region No Mods Required
    /// <summary>
    /// Get's all the script references required for this charactert
    /// </summary>
    private void SetUpReferences()
    {
        animController = GetComponent<AnimationController>(); // just getting a reference to our animation component on our dancer...this is behind the scenes for the dancing to occur.
        sfxHandler = FindObjectOfType<SFXHandler>(); // Finds a reference to our sfxHandler script that is in our scene.
        particleHandler = GetComponentInChildren<ParticleHandler>(); // searching through the child objects of this object to find the particle system.
        levellingSystem = GetComponent<LevellingSystem>(); // grab a reference to our levelling system
        uIManager = FindObjectOfType<UIManager>(); // grab a reference to the UI manager
        statsSystem = GetComponent<StatsSystem>(); // grab a reference to our stats system
        battleSystem = GetComponent<BattleSystem>(); // grab a reference to our battle system.
    }

    /// <summary>
    /// If our statsUI field is not null, then we pass in a reference to ourself and update the stats.
    /// </summary>
    public void UpdateStatsUI()
    {
        // this just updates our UI for our character to show new stats.
        if (statsUI != null)
        {
            statsUI.UpdateStatsUI(this); // pass in a reference to our own stat script.
        }
    }

    public void SetPercentageToWin(StatsSystem opponent = null)
    {
        if(statsUI != null)
        {
            if (opponent != null)
            {
                statsUI.SetChanceToWin(battleSystem.ReturnChanceToWin(BattleSystem.ReturnDancePowerLevel(statsSystem.style, statsSystem.rhythm, statsSystem.luck),
                    BattleSystem.ReturnDancePowerLevel(opponent.style, opponent.rhythm, opponent.luck)));
            }
            else
            {
                statsUI.SetChanceToWin(0);
            }
        }
    }

    /// <summary>
    /// Shows the level up effects whenever the character has levelled up
    /// </summary>
    public void ShowLevelUpEffects()
    {
        // plays the level up sound effect.
        sfxHandler.LevelUp();
        // emits a particle effect to show we have levelled up
        particleHandler.Emit();
        // Displays a UI Message to the player we have levelled up
        uIManager.ShowLevelUI();
    }
    #endregion 
}
