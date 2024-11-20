using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class G004_Backpack : MonoBehaviour
{
    public enum CompPost { Outside, Bag };
    public enum Component { GreenChudidar, Liptick, RedChudidar, YellowChudidar, Necklace, RedTB, Jhumka, RedSaree, BlackSaree, BlueJeans, GreenTop }
    public float totalWeight;
    public float maxWeight;
    public List<Component> essentialComps, bagContents;
    [SerializeField] G004_DB _DB;
    bool IsEssAvailable
    {
        get => bagContents.All(o => essentialComps.Contains(o));
    }

    private void OnEnable()
    {
        G004_BPEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
    }

    private void OnDisable()
    {
        G004_BPEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
    }

    private void G004_BPEvents_OnComponetDrop(G004_Backpack.Component obj, bool intoTheBag)
    {
        if (intoTheBag)
        {
            totalWeight += _DB.GetWeight(obj);
            bagContents.Add(obj);
        }
        else
        {
            totalWeight -= _DB.GetWeight(obj);
            bagContents.Remove(obj);
        }
    }

    private void SubmitGame()
    {
        if (totalWeight <= maxWeight && IsEssAvailable)
        {
            G004_GameEvents.GameSuccess();
        }
        else
        {
            G004_GameEvents.GameFailed();
        }
    }
}

