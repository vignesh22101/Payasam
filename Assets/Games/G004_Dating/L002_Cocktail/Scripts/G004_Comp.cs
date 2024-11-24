using UnityEngine;

public class G004_Comp : G004_DragAndDropSprite
{
    public G004_Shaker.Component comp;
    public G004_Shaker.CompPost pos, initialPos;
    [SerializeField] bool isInDropZone = false;
    [SerializeField] bool returnHome;
    public Vector3 homePos;

    public override void Start()
    {
        base.Start();
        isInDropZone = false;
        homePos = transform.position;
    }

    private void OnEnable()
    {
        G004_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        G004_GameEvents.OnSubmit += G004_GameEvents_OnSubmit;
    }

    private void G004_GameEvents_OnSubmit()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
        G004_DragDropEvents.OnComponetDrop -= G004_BPEvents_OnComponetDrop;
        G004_GameEvents.OnSubmit -= G004_GameEvents_OnSubmit;
    }

    private void G004_BPEvents_OnComponetDrop(G004_Shaker.Component comp, bool isInBag)
    {
        if (comp == this.comp)
        {
            //pos = isInBag ? G004_Shaker.CompPost.Inside : G004_Shaker.CompPost.Outside;
            if (!returnHome)
            {
                GetComponent<BoxCollider2D>().enabled = !isInBag;
                GetComponentInChildren<SpriteRenderer>().enabled = !isInBag;
            }

            if (returnHome)
            {
                pos = G004_Shaker.CompPost.Outside;
                transform.position = homePos;
            }
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
        pos = isInDropZone ? G004_Shaker.CompPost.Inside : G004_Shaker.CompPost.Outside;
    }

    public override void EndDrag()
    {
        base.EndDrag();

        if (pos != initialPos)
        {
            if (initialPos == G004_Shaker.CompPost.Outside)
                G004_DragDropEvents.ComponentDropped(comp, true);
            else
                G004_DragDropEvents.ComponentDropped(comp, false);
        }
        else
        {
            GetComponent<Transform>().position = homePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<G004_Shaker>())
        {
            isInDropZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<G004_Shaker>())
        {
            isInDropZone = false;
        }
    }

    private void OnValidate()
    {
        name = comp.ToString();
    }
}
