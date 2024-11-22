using System;
using UnityEngine;
using UnityEngine.UI;

public class G003_SubmitButton : MonoBehaviour
{
    [SerializeField] G003_Backpack backpack;

    private void Start()
    {
        RefreshStatus();
    }

    private void OnEnable()
    {
        G003_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        G003_GameEvents.SubmitGame();
        GetComponent<Button>().interactable = false;
    }

    private void OnDisable()
    {
        G003_DragDropEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    private void G004_BPEvents_OnComponetDrop(G003_Backpack.Component obj, bool intoTheBag)
    {
        Invoke(nameof(RefreshStatus), 0.1f);
    }

    void RefreshStatus()
    {
        GetComponent<Button>().interactable = backpack.bagContents.Count > 0;
    }
}