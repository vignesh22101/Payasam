using System;
using UnityEngine;
using UnityEngine.UI;

public class G003_SubmitButton : MonoBehaviour
{
    [SerializeField] G004_Backpack backpack;

    private void Start()
    {
        RefreshStatus();
    }

    private void OnEnable()
    {
        G004_BPEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        G004_GameEvents.SubmitGame();
        GetComponent<Button>().interactable = false;
    }

    private void OnDisable()
    {
        G004_BPEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    private void G004_BPEvents_OnComponetDrop(G004_Backpack.Component obj, bool intoTheBag)
    {
        Invoke(nameof(RefreshStatus), 0.1f);
    }

    void RefreshStatus()
    {
        GetComponent<Button>().interactable = backpack.bagContents.Count > 0;
    }
}