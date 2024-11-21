using UnityEngine;

public class G004_Comp : G003_DragAndDropSprite
{
    public G004_Backpack.Component comp;
    public G004_Backpack.CompPost pos, initialPos;
    public float minDistanceForBagDrop = 0.1f;
    [SerializeField] G004_Backpack backpack;
    bool isInDropZone = false;
    public Vector3 homePos;

    public override void Start()
    {
        base.Start();
        isInDropZone = false;
        homePos = transform.position;
    }

    private void OnEnable()
    {
        G004_BPEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        G004_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void G004_GameEvents_OnSubmit()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
        G004_BPEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
        G004_GameEvents.OnSubmit -= G004_GameEvents_OnSubmit;
    }

    private void G004_BPEvents_OnComponetDrop(G004_Backpack.Component comp, bool isInBag)
    {
        if (comp == this.comp)
        {
            pos = isInBag ? G004_Backpack.CompPost.Bag : G004_Backpack.CompPost.Outside;
            GetComponent<BoxCollider2D>().enabled = !isInBag;
            GetComponent<SpriteRenderer>().enabled = !isInBag;
            if (pos == G004_Backpack.CompPost.Outside)
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
        pos = isInDropZone ? G004_Backpack.CompPost.Bag : G004_Backpack.CompPost.Outside;
    }

    public override void EndDrag()
    {
        base.EndDrag();

        if (pos != initialPos && !backpack.WeightLimitExceeded)
        {
            if (initialPos == G004_Backpack.CompPost.Outside)
                G004_BPEvents.ComponentDropped(comp, true);
            else
                G004_BPEvents.ComponentDropped(comp, false);
        }
        else
        {
            GetComponent<Transform>().position = originalPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<G004_Backpack>())
        {
            isInDropZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<G004_Backpack>())
        {
            isInDropZone = false;
        }
    }

    private void OnValidate()
    {
        name = comp.ToString();
    }
}
