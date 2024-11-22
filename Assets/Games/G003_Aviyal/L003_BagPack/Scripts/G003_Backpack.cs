using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class G003_Backpack : MonoBehaviour
{
    public enum CompPost { Outside, Inside };
    public enum Component { GreenChudidar, Liptick, RedChudidar, YellowChudidar, Necklace, RedTB, Jhumka, RedSaree, BlackSaree, BlueJeans, GreenTop }
    private float totalWeight;
    public float maxWeight;
    public List<Component> essentialComps, bagContents;
    [SerializeField] G003_DB _DB;
    [SerializeField] TextMeshProUGUI weightTxt;
    bool IsEssAvailable
    {
        get => essentialComps.All(o => bagContents.Contains(o));
    }
    public bool WeightLimitExceeded => totalWeight <= maxWeight;
    public float TotalWeight
    {
        get => totalWeight; set
        {
            totalWeight = value;
            weightTxt.text = totalWeight.ToString() + "g";
        }
    }

    private void Start()
    {
        TotalWeight = 0f;
    }


    private void OnEnable()
    {
        G003_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        G003_GameEvents.OnSubmit += SubmitGame;
    }

    private void OnDisable()
    {
        G003_DragDropEvents.OnComponetDrop += G004_BPEvents_OnComponetDrop;
        G003_GameEvents.OnSubmit -= SubmitGame;
    }

    private void G004_BPEvents_OnComponetDrop(G003_Backpack.Component obj, bool intoTheBag)
    {
        if (intoTheBag)
        {
            Debug.Log(obj.ToString());
            TotalWeight += _DB.GetWeight(obj);
            bagContents.Add(obj);
        }
        else
        {
            TotalWeight -= _DB.GetWeight(obj);
            bagContents.Remove(obj);
        }
    }

    private void SubmitGame()
    {
        if (TotalWeight <= maxWeight && IsEssAvailable)
        {
            G003_GameEvents.GameSuccess();
        }
        else
        {
            G003_GameEvents.GameFailed();
        }
    }
}
