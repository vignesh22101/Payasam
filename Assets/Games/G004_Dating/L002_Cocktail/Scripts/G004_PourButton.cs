using UnityEngine;
using UnityEngine.UI;

public class G004_PourButton : MonoBehaviour
{
    public GameObject emptyGlass, fullGlass;
    public static bool poured = false;
    [SerializeField] G004_ScoreSystem scoreSys;


    private void Start()
    {
        emptyGlass.SetActive(true);
        fullGlass.SetActive(false);
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Pour();
    }

    public void Pour()
    {
        emptyGlass.SetActive(false);
        fullGlass.SetActive(true);
        gameObject.SetActive(false);
        poured = true;
        scoreSys.RefreshScore();
    }
}