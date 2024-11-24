using TMPro;
using UnityEngine;

public class G004_TextNotifier : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBP;

    private void OnEnable()
    {
        G004_DragDropEvents.OnComponetDrop += G004_DragDropEvents_OnComponetDrop;
    }

    private void OnDisable()
    {
        G004_DragDropEvents.OnComponetDrop -= G004_DragDropEvents_OnComponetDrop;
    }

    private void G004_DragDropEvents_OnComponetDrop(G004_Shaker.Component droppedComp, bool insideTheShaker)
    {
        TextMeshProUGUI instance = Instantiate(textBP, transform.parent.transform);
        instance.gameObject.SetActive(true);
        instance.text = $"Added {droppedComp.ToString()}";
    }
}
