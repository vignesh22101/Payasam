using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cocktail/StepsDB", menuName = "Cocktail/DB", order = 1)]
public class G003_PDB : ScriptableObject
{
    [SerializeField] List<PSteps> steps;

}

[System.Serializable]
public class PSteps
{
    public string instruction;
    public float time;
}
