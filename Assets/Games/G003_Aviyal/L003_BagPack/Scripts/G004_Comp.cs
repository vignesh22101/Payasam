using UnityEngine;
using UnityEngine.EventSystems;

public class G004_Comp : G004_DragDropMobileUI
{
    public G004_Backpack.Component comp;
    public G004_Backpack.CompPost pos, initialPos;
    public float minDistanceForBagDrop = 0.1f;
    [SerializeField] G004_Backpack backpack;
    Vector2 backpackScreenPosition2D;
    bool IsInDropZone
    {
        get
        {

            // Ignore the Z-axis by using only X and Y for distance calculation

            // Calculate the distance between the UI element and the backpack in screen space
            float distance = Vector2.Distance(transform.position, backpackScreenPosition2D);
            Debug.Log(distance);
            return distance < minDistanceForBagDrop;
        }
    }

    private void Start()
    {
        Vector3 backpackScreenPosition = Camera.main.WorldToScreenPoint(backpack.transform.position);
        backpackScreenPosition2D = new Vector2(backpackScreenPosition.x, backpackScreenPosition.y);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        initialPos = pos;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        pos = IsInDropZone ? G004_Backpack.CompPost.Bag : G004_Backpack.CompPost.Outside;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (pos != initialPos)
        {
            if (initialPos == G004_Backpack.CompPost.Outside)
                G004_BPEvents.ComponentDropped(comp, true);
            else
                G004_BPEvents.ComponentDropped(comp, false);
        }
        else
        {
            GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }
    }

    private void OnValidate()
    {
        name = comp.ToString();
    }
}
