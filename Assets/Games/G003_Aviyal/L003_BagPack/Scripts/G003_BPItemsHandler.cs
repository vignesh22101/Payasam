using System.Collections.Generic;
using UnityEngine;

public class G003_BPItemsHandler : MonoBehaviour
{
    public List<G003_BPItem> items;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        items.ForEach(o => G004_BPEvents_OnComponetDrop(o.comp, false));
    }

    private void OnEnable()
    {
        G003_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
    }

    private void OnDisable()
    {
        G003_DragDropEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
    }

    private void G004_BPEvents_OnComponetDrop(G003_Backpack.Component comp, bool isInBag)
    {
        items.ForEach(item =>
        {
            if (item.comp == comp)
            {
                item.gameObject.SetActive(isInBag);
            }
        });
    }
}
