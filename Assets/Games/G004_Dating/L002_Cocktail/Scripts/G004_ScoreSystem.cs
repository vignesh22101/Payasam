using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class G004_ScoreSystem : MonoBehaviour
{
    [SerializeField] G004_CDB db;
    [SerializeField] List<G004_ScoreData> scoreData;
    internal float maxScore = 7, currentScore, quantityScore, actionScore;
    int currInsIndex = 0;
    [SerializeField] List<G004_Shaker.Component> compsUsed;
    [SerializeField] Slider scoreSlider;
    [SerializeField] G004_InstructionPanel insPanel;
    List<int> indexesProcessed;
    public bool inbalancedDrink;
    public bool notGarnished => !compsUsed.Contains(G004_Shaker.Component.Orange) ||
        !compsUsed.Contains(G004_Shaker.Component.Cherry);
    public float FinalScore
    {
        get
        {
            ProcessQuantityScore();
            return (((currentScore / maxScore) * 100) + quantityScore + actionScore) / 3f;
        }
    }

    private void Start()
    {
        indexesProcessed = new List<int>();
        compsUsed = new List<G004_Shaker.Component>();
        currentScore = 0;
        currInsIndex = 0;
        scoreSlider.value = 0;
    }

    private void OnEnable()
    {
        G004_DragDropEvents.OnComponetDrop += G004_DragDropEvents_OnComponetDrop;
        G004_GameEvents.OnTimerDestroyed += G004_GameEvents_OnTimerDestroyed;
    }

    private void G004_GameEvents_OnTimerDestroyed()
    {
        RefreshScore();
    }

    private void OnDisable()
    {
        G004_DragDropEvents.OnComponetDrop -= G004_DragDropEvents_OnComponetDrop;
        G004_GameEvents.OnTimerDestroyed -= G004_GameEvents_OnTimerDestroyed;
    }

    private void G004_DragDropEvents_OnComponetDrop(G004_Shaker.Component droppedComp, bool insideTheShaker)
    {
        ProcessScore(droppedComp);
        compsUsed.Add(droppedComp);
    }

    public void RefreshScore()
    {
        ProcessScore(G004_Shaker.Component.None);
    }

    public void ProcessScore(G004_Shaker.Component droppedComp)
    {
        if (db.steps[insPanel.instructionIndex].comp != G004_Shaker.Component.None &&
            !indexesProcessed.Contains(insPanel.instructionIndex))
        {
            indexesProcessed.Add(insPanel.instructionIndex);
            if (droppedComp == db.steps[insPanel.instructionIndex].comp)
                currentScore += 1;
            else
                currentScore -= 1;
        }

        if (currentScore <= 0)
            currentScore = 0;

        ProcessQuantityScore();
        ProcessActionScore();
        Debug.Log($"as:{actionScore}, qs:{quantityScore}, cs:{this.currentScore}");
        scoreSlider.value = FinalScore;
    }

    void ProcessActionScore()
    {
        float shakeScore = G004_Shaker.shakeCount >= 3f ? 1f : 0f;
        float purScore = G004_PourButton.poured ? 1f : 0f;
        actionScore = (shakeScore + purScore) / 2f;
        actionScore *= 100f;
    }

    private void ProcessQuantityScore()
    {
        int maxScore = scoreData.Count;
        float currScore = 0;

        foreach (var item in scoreData)
        {
            if (compsUsed.Count(o => o == item.comp) == item.desiredCount)
                currScore += 1;
            else if (compsUsed.Count(o => o == item.comp) == 0)
                currScore += 0f;
            else
                currScore += 0.1f;

            if (compsUsed.Count(o => o == item.comp) > item.desiredCount)
                inbalancedDrink = true;
        }

        quantityScore = (currScore / maxScore) * 100f;
    }

    public void GetScore()
    {

    }
}

[System.Serializable]
public class G004_ScoreData
{
    public G004_Shaker.Component comp;
    public int desiredCount = 1;
}
