﻿using System.Collections.Generic;
using UnityEngine;

public class G003_UIManager : MonoBehaviour
{
    [SerializeField] bool retryAvaiable;
    [SerializeField] GameObject retryUI, successUI ,failedUI;
    [SerializeField] List<GameObject> disableOnStart,disableOnSubmit;

    private void Start()
    {
        disableOnStart.ForEach(o=>o.SetActive(false));
    }

    private void OnEnable()
    {
        G003_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
        G003_GameEvents.OnFailed += G004_GameEvents_OnFailed;
        G003_GameEvents.OnSuccess += G004_GameEvents_OnSuccess; ;
    }

    private void G004_GameEvents_OnSuccess()
    {
        if (successUI)
            successUI.SetActive(true);
    }

    private void G004_GameEvents_OnFailed()
    {
        if (retryAvaiable)
        {
            if (retryUI != null)
            {
                retryUI.SetActive(true);
            }
        }
        else
        {
            if (failedUI)
            {
                failedUI.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        G003_GameEvents.OnSuccess -= G004_GameEvents_OnSuccess; ;
        G003_GameEvents.OnSubmit -= G004_GameEvents_OnSubmit;
        G003_GameEvents.OnFailed -= G004_GameEvents_OnFailed;
    }

    private void G004_GameEvents_OnSubmit()
    {
        disableOnSubmit.ForEach(o => o.SetActive(false));
    }
}
