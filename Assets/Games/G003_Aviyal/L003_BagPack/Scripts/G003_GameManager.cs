using UnityEngine;

public class G003_GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        G003_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void OnDisable()
    {
        G003_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void G004_GameEvents_OnSubmit()
    {

    }
}
