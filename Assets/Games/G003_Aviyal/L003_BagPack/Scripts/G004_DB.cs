using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BP_DB", menuName = "Assets/Create/Bagpack/DB", order = 1)]
public class G004_DB : ScriptableObject
{
    public List<G004_ComponentCl> componentsData;

    public float GetWeight(G004_Backpack.Component comp)
    {
        return componentsData.Find(o => o.comp == comp).weight;
    }
}

