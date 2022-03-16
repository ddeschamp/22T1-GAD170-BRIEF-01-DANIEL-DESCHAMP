using System.Collections;
using UnityEngine;

/// <summary>
/// Splashes simple ui elements when certain game events are triggered
/// 
/// Provided with framework, no modification required
/// </summary>
public class UIManager : MonoBehaviour
{
    public GameObject npcLevelUI;


    public StatsUI npcStatsUI; // only show/update when player is in range.
    
    public void EnableNPCStatsUI(bool enabled)
    {
        npcStatsUI.gameObject.SetActive(enabled);
    }


    public void ShowLevelUI()
    {
        StartCoroutine(NPCLevelUI());
    }

    public void ShowXpGainOnUI(int xp, Transform character)
    {
        if (!character.GetComponent<BriefManager>())
        {
            return;
        }
        StartCoroutine(PlayerXPUI(xp, character));
    }

    IEnumerator NPCLevelUI()
    {
        npcLevelUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        npcLevelUI.SetActive(false);
    }

    IEnumerator PlayerXPUI(int xp, Transform character)
    {
        int xpDisplay = 0;
        character.GetComponent<BriefManager>().xpUI.SetActive(true);
        while (xpDisplay < xp)
        {
            xpDisplay++;
            character.GetComponent<BriefManager>().xpUI.GetComponentInChildren<UnityEngine.UI.Text>().text = "+" + xpDisplay.ToString() + "XP";
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        character.GetComponent<BriefManager>().xpUI.SetActive(false);
    }
}
