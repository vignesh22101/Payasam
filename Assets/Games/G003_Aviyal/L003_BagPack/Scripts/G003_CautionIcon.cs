using UnityEngine;
using UnityEngine.UI;

public class G003_CautionIcon : MonoBehaviour
{
    [SerializeField] G003_Backpack backpack;

    private void Start()
    {
        Refresh();
    }

    private void OnEnable()
    {
        G003_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
    }

    private void OnDisable()
    {
        G003_DragDropEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
    }

    private void G004_BPEvents_OnComponetDrop(G003_Backpack.Component arg1, bool arg2)
    {
        Invoke(nameof(Refresh),0.1f);
    }

    private void Refresh()
    {
        bool status = backpack.WeightLimitExceeded;

        GetComponent<Image>().enabled = status;
    }
}
