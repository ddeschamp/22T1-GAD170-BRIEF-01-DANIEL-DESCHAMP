using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Agent to dance against.
/// 
/// Provided with framework, no modification required
/// </summary>
public class NPC : MonoBehaviour
{
    [HideInInspector]
    public BriefManager myStats;
    public GameObject uiCanvas;

    private void Awake()
    {
        myStats = GetComponent<BriefManager>();

        if (uiCanvas == null)
        {
            uiCanvas = transform.GetChild(0).gameObject;
          
        }
        uiCanvas.SetActive(false);
    }
}