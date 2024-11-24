using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BP_DB", menuName = "Assets/Create/Bagpack/DB", order = 1)]
public class G003_DB : ScriptableObject
{
    public List<G003_ComponentCl> componentsData;

    public float GetWeight(G003_Backpack.Component comp)
    {
        Debug.Log("Getting weight for " + comp.ToString()); ;
        return componentsData.Find(o => o.comp == comp).weight;
    }
}

