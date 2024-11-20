using UnityEngine;

public class G001_ResortModelViewer : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Vector3 lastMousePosition;

    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            float rotationX = delta.y * rotationSpeed * Time.deltaTime;
            float rotationY = -delta.x * rotationSpeed * Time.deltaTime;


            transform.Rotate(0, rotationY, 0, Space.World);
        }

        lastMousePosition = Input.mousePosition;
    }
}
