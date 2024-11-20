using UnityEngine;

public class G004_UIManager : MonoBehaviour
{
    [SerializeField] bool retryAvaiable;
    [SerializeField] GameObject retryUI,successUI;

    private void OnEnable()
    {
        G004_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
        G004_GameEvents.OnFailed += G004_GameEvents_OnFailed;
        G004_GameEvents.OnSuccess += G004_GameEvents_OnSuccess; ;
    }

    private void G004_GameEvents_OnSuccess()
    {
        if(successUI)
            successUI.SetActive(true);
    }

    private void G004_GameEvents_OnFailed()
    {
        if (retryAvaiable)
        {
            if (retryUI != null)
            {
                retryUI.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        G004_GameEvents.OnSuccess -= G004_GameEvents_OnSuccess; ;
        G004_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
        G004_GameEvents.OnFailed -= G004_GameEvents_OnFailed;
    }

    private void G004_GameEvents_OnSubmit()
    {
      
    }
}
