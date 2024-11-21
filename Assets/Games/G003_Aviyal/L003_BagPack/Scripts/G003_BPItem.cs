using UnityEngine;

public class G003_BPItem : MonoBehaviour
{
    public G004_Backpack.Component comp;

    private void OnValidate()
    {
        name = comp.ToString();
    }
}