using UnityEngine;

public class G003_DisableDragAndDrop : MonoBehaviour
{
    public static bool DisableDragAndDrop = false;

    private void OnEnable()
    {
        DisableDragAndDrop = true;
    }

    private void OnDisable()
    {
        DisableDragAndDrop = false;
    }
}