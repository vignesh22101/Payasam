﻿using UnityEngine;

public class G003_BPItemStatus : MonoBehaviour
{
    [SerializeField] GameObject unpackPrefab;
    [SerializeField] G004_Backpack backpack;

    private void OnEnable()
    {
        backpack.bagContents.ForEach(item =>
        {
            Setup(item);
        });
    }

    private void Setup(G004_Backpack.Component comp)
    {
        G003_UnpackItem instance = Instantiate(unpackPrefab.gameObject, transform).GetComponent<G003_UnpackItem>();
        instance.comp = comp;
        instance.Initialize();
    }
}