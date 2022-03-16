using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds all the logic for our battle system, so being able to calculate the percentage chance of us winning.
/// 
///TODO:
///     - Battle needs to handle the logic for who wins a fight and telling the winner they get some XP for their trouble.
///     - ReturnDancePowerLevel needs a formula to calculate what a chacters power level is.
/// </summary>
public class BattleSystem : MonoBehaviour
{

    /// <summary>
    /// Returns a float perecentage of the percentage chance this character has to win.
    /// </summary>
    /// <param name="MyPowerLevel"></param>
    /// <param name="OppositionsPowerLevel"></param>
    /// <returns></returns>
    public float ReturnChanceToWin(int MyPowerLevel, int OppositionsPowerLevel)
    {
        // TODO Calculate the percentage of MyPowerLevel, compared to the overall power.
        return 0;
    }

    /// <summary>
    /// Used to generate a number of battle points that is used in combat.
    /// </summary>
    /// <returns></returns>
    public static int ReturnDancePowerLevel(int Style, int Luck, int Rythmn)
    {
        // TODO We want to design some algorithm that will generate a number of points based off of our luck,style and rythm, we probably want to add some randomness in our calculation too
        // to ensure that there is not always a draw, by default it just returns 0. 
        // If you right click this function and find all references you can see where it is called.
        // Let's also throw in a little randomness in here, so it's not a garunteed win
        Debug.LogWarning("ReturnBattlePoints has been called we probably want to create some battle points based on our stats");
        return 0;
    }

    #region No Mods Required
    /// <summary>
    /// A method attached to a button that would allow us to check that our logic works as intentended
    /// No modification needed here, if your logic is sound you should be able to get expected values.
    /// </summary>
    public void TestImplementation()
    {
        int oppositionsPowerLevel = ReturnDancePowerLevel(10, 20, 30);
        int myPowerLevel = ReturnDancePowerLevel(30, 20, 10);

        Debug.Log(string.Format("My stats are: Style {0}, Luck {1} Rhytmn {2} , my power level is: {3}", 30, 20, 10, myPowerLevel));
        Debug.Log(string.Format("Opponent stats are: Style {0}, Luck {1} Rhytmn {2} , my power level is: {3}", 10, 20, 30, oppositionsPowerLevel));

        // Calculate my chance for winning.
        Debug.Log(string.Format("My Chance to win is: {0}%", ReturnChanceToWin(myPowerLevel, oppositionsPowerLevel)));
        Debug.Log(string.Format("Opponent's Chance to win is: {0}%", ReturnChanceToWin(oppositionsPowerLevel, myPowerLevel)));
    }
    #endregion
}
