﻿using System.Collections.Generic;
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
        G004_BPEvents_OnComponetDrop(G004_Backpack.Component.Necklace, false);
    }

    private void OnEnable()
    {
        G004_BPEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
    }

    private void OnDisable()
    {
        G004_BPEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
    }

    private void G004_BPEvents_OnComponetDrop(G004_Backpack.Component comp, bool isInBag)
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