﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text charNameText;
    public Text levelText;
    public Text xpText;
    public Text strengthText;
    public Text agilityText;
    public Text intelligenceText;
    public Text rhythmText;
    public Text styleText;
    public Text luckText;
    public Text percentageWin;
    
    /// <summary>
    /// Updates the text fields to display the current stats of our character.
    /// </summary>
    /// <param name="characterStats"></param>
    public void UpdateStatsUI(BriefManager characterStats)
    {
        // set the text for each of pieces of text.
        SetText(charNameText, characterStats.gameObject.name);
        SetText(levelText, "Level: " + characterStats.levellingSystem.curretLevel);
        SetText(xpText, "Xp: " + characterStats.levellingSystem.currentXp + "/" + characterStats.levellingSystem.currentXPThreshold);
        SetText(strengthText, "Str: " + characterStats.statsSystem.strength);
        SetText(agilityText, "Agil: " + characterStats.statsSystem.agility);
        SetText(intelligenceText, "Int: " + characterStats.statsSystem.intelligence);
        SetText(rhythmText, "Rhythm: " + characterStats.statsSystem.rhythm);
        SetText(styleText, "Style: " + characterStats.statsSystem.style);
        SetText(luckText, "Luck: " + characterStats.statsSystem.luck);
    }

    public void SetChanceToWin(float amount)
    {
        SetText(percentageWin, "Chance to win: " + amount + "%");
    }

    /// <summary>
    /// Takes in a text element and a string for the text. 
    /// if the text field is not null then set it to the string text.
    /// </summary>
    /// <param name="textToSet"></param>
    /// <param name="text"></param>
    private void SetText(Text textToSet, string text)
    {
        if (textToSet != null)
        {
            textToSet.text = text;
        }
        else
        {
            Debug.Log("The text you are trying to set field is null");
        }
    }
}
