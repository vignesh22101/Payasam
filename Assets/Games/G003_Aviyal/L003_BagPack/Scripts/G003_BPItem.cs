using UnityEngine;

public class G003_BPItem : MonoBehaviour
{
    public G003_Backpack.Component comp;

    private void OnValidate()
    {
        name = comp.ToString();
    }
}