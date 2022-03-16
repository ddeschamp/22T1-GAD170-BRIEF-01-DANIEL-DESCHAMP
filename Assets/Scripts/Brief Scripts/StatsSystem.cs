using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds all the logic for our stats system, so that includes logic to handle generating starting physical stats
/// calculating our dancing stats based on physical stats and our stat multipliers.
/// 
///TODO:
///     - GeneratePhysicalStatsStats needs to generate some random starting stats.
///     - CalculateDancingStats needs to calculate our lucky, style, ryhtmn based on  our physical stats and our stat multipliers.
///     - DistributePhysicalStatsOnLevelUp takes in some statpoints to distribute we want to increase our physical stats by them and recalculate our dancing stats.
/// </summary>
public class StatsSystem : MonoBehaviour
{
    /// <summary>
    /// Our variables used to determine our fighting power.
    /// </summary>
    public int style;
    public int luck;
    public int rhythm;

    /// <summary>
    /// Our physical stats that determine our dancing stats.
    /// </summary>
    public int agility;
    public int intelligence;
    public int strength;

    /// <summary>
    /// Used to determine the conversion of 1 physical stat, to 1 dancing stat.
    /// </summary>
    public float agilityMultiplier = 0.5f;
    public float strengthMultiplier = 1f;
    public float inteligenceMultiplier = 2f;


    /// <summary>
    /// This function should set our starting stats of Agility, Strength and Intelligence
    /// to some default RANDOM values.
    /// </summary>
    public void GeneratePhysicalStatsStats()
    {
        // Let's set up agility, intelligence and strength to some default Random values.

    }

    /// <summary>
    /// This function should set our style, luck and ryhtmn to values
    /// based on our currrent agility,intelligence and strength.
    /// </summary>
    public void CalculateDancingStats()
    {
        // what we want I want is for you to take our physical stats and translate them into our dancing stats,
        // based on the multiplier of that stat as follows:
        // our Style should be based on our Agility and Agility multiplier.
        // our Rhythm should be based on our Strength and Strength multiplier.
        // our Luck should be based on our intelligence and our Intelligence multiplier.
        // hint...your going to need to convert our ints into floats, then back to ints.

    }

    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// </summary>
    public void DistributePhysicalStatsOnLevelUp(int PointsPool)
    {
        // let's share these points somewhat evenly or based on some forumal to increase our current physical stats
        // then let's recalculate our dancing stats again to process and update the new values.
    }

    #region No Mods Required
    /// <summary>
    /// A method attached to a button that would allow us to check that our logic works as intentended
    /// No modification needed here, if your logic is sound you should be able to get expected values.
    /// </summary>
    public void TestImplementation()
    {
        // calculate and print our physical stats
        GeneratePhysicalStatsStats();
        Debug.Log(string.Format("Our starting physical stats would be: str {0}, agil {1}, int {2}", strength, agility, intelligence));

        // calculate and print our dancing stats
        CalculateDancingStats();
        Debug.Log(string.Format("Our starting dancing stats would be: rhythm {0}, style {1}, luck {2}", rhythm, style, luck));

        // we magically levelled up
        Debug.Log("WE'VE LEVELLED UP!");

        // call our distribute stats.
        DistributePhysicalStatsOnLevelUp(10);
        Debug.Log(string.Format("Our new physical stats would be: str {0}, agil {1}, int {2}", strength, agility, intelligence));
        Debug.Log(string.Format("Our new dancing stats would be: rhythm {0}, style {1}, luck {2}", rhythm, style, luck));
        // output what the theoretical values would be
    }
    #endregion
}
