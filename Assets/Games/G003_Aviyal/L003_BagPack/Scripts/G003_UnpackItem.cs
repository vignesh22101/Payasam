using UnityEngine;
using UnityEngine.UI;

public class G003_UnpackItem : MonoBehaviour
{
    public G004_Backpack.Component comp;
    public Image visual;
    public Button button;
    [SerializeField] G004_DB db;

    public void Initialize()
    {
        visual.sprite = db.componentsData.Find(o => o.comp == comp).sprite;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
        SelfTerminate();
    }

    private void OnClick()
    {
        G004_BPEvents.ComponentDropped(comp, false);
        SelfTerminate();
    }

    private void SelfTerminate()
    {
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        //transform.parent.name = "BPItem_" + comp.ToString();
    }
}
