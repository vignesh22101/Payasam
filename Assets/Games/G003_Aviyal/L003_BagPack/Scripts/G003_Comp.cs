using UnityEngine;

public class G003_Comp : G003_DragAndDropSprite
{
    public G003_Backpack.Component comp;
    public G003_Backpack.CompPost pos, initialPos;
    [SerializeField] G003_Backpack backpack;
    [SerializeField] bool isInDropZone = false;
    public Vector3 homePos;

    public override void Start()
    {
        base.Start();
        isInDropZone = false;
        homePos = transform.position;
    }

    private void OnEnable()
    {
        G003_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        G003_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void G004_GameEvents_OnSubmit()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
        G003_DragDropEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
        G003_GameEvents.OnSubmit -= G004_GameEvents_OnSubmit;
    }

    private void G004_BPEvents_OnComponetDrop(G003_Backpack.Component comp, bool isInBag)
    {
        if (comp == this.comp)
        {
            pos = isInBag ? G003_Backpack.CompPost.Inside : G003_Backpack.CompPost.Outside;
            GetComponent<BoxCollider2D>().enabled = !isInBag;
            GetComponentInChildren<SpriteRenderer>().enabled = !isInBag;
            if (pos == G003_Backpack.CompPost.Outside)
                transform.position = homePos;
        }
    }

    public override void BeginDrag()
    {
        base.BeginDrag();
        initialPos = pos;
    }

    public override void ContinueDrag()
    {
        base.ContinueDrag();
        pos = isInDropZone ? G003_Backpack.CompPost.Inside : G003_Backpack.CompPost.Outside;
    }

    public override void EndDrag()
    {
        base.EndDrag();

        if (pos != initialPos && !backpack.WeightLimitExceeded)
        {
            if (initialPos == G003_Backpack.CompPost.Outside)
                G003_DragDropEvents.ComponentDropped(comp, true);
            else
                G003_DragDropEvents.ComponentDropped(comp, false);
        }
        else
        {
            GetComponent<Transform>().position = homePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<G003_Backpack>() && !backpack.WeightLimitExceeded)
        {
            isInDropZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<G003_Backpack>() && !backpack.WeightLimitExceeded)
        {
            isInDropZone = false;
        }
    }

    private void OnValidate()
    {
        name = comp.ToString();
    }
}
