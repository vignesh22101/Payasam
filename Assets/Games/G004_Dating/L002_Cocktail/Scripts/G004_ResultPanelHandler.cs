using UnityEngine;

public class G004_ResultPanelHandler : MonoBehaviour
{
    [SerializeField] GameObject successPanel, tooStrongPanel, notMixedPanel, notGarnishedPanel, failedPanel;
    [SerializeField] G004_ScoreSystem scoreSys;

    public void Result()
    {
        if (G004_Shaker.shakeCount < 3f)
        {
            notMixedPanel.SetActive(true);
        }
        else if (scoreSys.inbalancedDrink)
        {
            tooStrongPanel.SetActive(true);
        }
        else if (scoreSys.notGarnished)
        {
            notGarnishedPanel.SetActive(true);
        }
        else if (scoreSys.currentScore < scoreSys.maxScore)
        {
            failedPanel.SetActive(true);
        }
        else
        {
            successPanel.SetActive(true);
        }
    }
}
