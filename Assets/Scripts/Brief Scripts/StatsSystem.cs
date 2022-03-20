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
    public int rhythm;
    public int style;
    public int luck;


    /// <summary>
    /// Our physical stats that determine our dancing stats.
    /// </summary>
    public int strength;
    public int agility;
    public int intelligence;

    // The statpool has been set to scale with level.
    public int statpool;


    /// <summary>
    /// Used to determine the conversion of 1 physical stat, to various dancing stats.
    /// </summary>
    public float strengthMultiplier = 2f;    
    public float dexterityMultiplier = 1.5f;
    public float charismaMultiplier = 1f;


    /// <summary>
    /// This function should set our starting stats of Strength, Dexterity and Charisma
    /// to some default RANDOM values.
    /// </summary>
    public void GeneratePhysicalStatsStats()
    {
        int statpool = 20;
        strength = Random.Range(1, statpool);
        statpool -= strength;
        agility = Random.Range(1, statpool);
        statpool -= agility;
        intelligence = statpool;
        statpool -= intelligence;
        Debug.Log("STR: " + strength);
        Debug.Log("DEX: " + agility);
        Debug.Log("CHA: " + intelligence);
        Debug.Log("Statpool: " + statpool);
        return;

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

        float strFloat = (float)strength;
        float rhyFloat = (strFloat * 2f); //I attempted to multiply this converted float by 'strengthMultiplier' but it didn't want to work properly, and so rhythm would equal strength on a 1:1 ratio.
        int rhyInt = (int)rhyFloat;
        rhythm = rhyInt;
        Debug.Log("RHY: "+ rhythm);
        float agiFloat = (float)agility;
        float styFloat = (agiFloat * 1.5f); //Same goes for agility multiplier.
        int styInt = (int)styFloat;
        style = styInt;
        Debug.Log("STY: " + style);
        float intFloat = (float)intelligence;
        float lckFloat = (intFloat * 1f); //Same goes for intelligence multiplier.
        int lckInt = (int)lckFloat;
        luck = lckInt;
        Debug.Log("LCK: " + luck);

    }

    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// </summary>
    public void DistributePhysicalStatsOnLevelUp(int statPool)
    {
        // let's share these points somewhat evenly or based on some forumal to increase our current physical stats
        // then let's recalculate our dancing stats again to process and update the new values.

        int newStr = Random.Range(1, statPool);
        statPool -= newStr;
        strength += newStr;
        int newAgi = Random.Range(1, statPool);
        statPool -= newAgi;
        agility += newAgi;
        int newInt = statPool;
        statPool -= newInt;
        intelligence += newInt;
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
