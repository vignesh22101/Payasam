using UnityEngine;

public class G004_GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        G004_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void OnDisable()
    {
        G004_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void G004_GameEvents_OnSubmit()
    {

    }
}
