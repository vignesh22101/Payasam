using UnityEngine;

public class G003_DragAndDropSprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    protected Vector3 originalPosition;

    public virtual void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
    }

    void Update()
    {
        if (G003_DisableDragAndDrop.DisableDragAndDrop)
            return;

        if (Input.GetMouseButtonDown(0)) // Start dragging
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPosition);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                originalPosition = transform.position;
                isDragging = true;
                offset = transform.position - mouseWorldPosition; // Calculate offset
                BeginDrag();
            }
        }

        if (Input.GetMouseButton(0) && isDragging) // Dragging
        {
            ContinueDrag();
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Stop dragging
        {
            EndDrag();
        }
    }

    public virtual void EndDrag()
    {
        isDragging = false;
    }

    public virtual void ContinueDrag()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        newPosition.z = transform.position.z; // Lock Z-axis
        transform.position = newPosition;
    }

    public virtual void BeginDrag()
    {

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // Distance from camera
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
