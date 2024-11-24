using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Payasam/StepsDB", menuName = "Payasam/DB", order = 1)]
public class G004_CDB : ScriptableObject
{
    public  List<CSteps> steps;

}

[System.Serializable]
public class CSteps
{
    public string instruction;
    public G004_Shaker.Component comp;
    public float time;
}
