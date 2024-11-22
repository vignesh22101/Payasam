using UnityEngine;

public class G003_MaintainAS : MonoBehaviour
{
    [SerializeField] float aspectratio;

    void OnEnable()
    {
        GetComponent<Camera>().aspect = aspectratio;
    }

    void Reset()
    {
        aspectratio = GetComponent<Camera>().aspect;
    }
}