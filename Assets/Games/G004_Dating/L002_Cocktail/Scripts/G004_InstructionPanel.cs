using TMPro;
using UnityEngine;

public class G004_InstructionPanel : MonoBehaviour
{
    [SerializeField] G004_CDB DB;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] public int instructionIndex;
    [SerializeField] GameObject timer;
    GameObject timerInstance;
    [SerializeField] GameObject shakeButton, shacker, shacketWithLid, pourButton;
    [SerializeField] int shakeInsIndex, pourButtonIndex;
    [SerializeField] G004_ResultPanelHandler resultPanel;

    private void Start()
    {
        instructionIndex = 0;
        RefreshInstructino();
    }

    private void OnEnable()
    {
        G004_GameEvents.OnTimerDestroyed += G004_DragDropEvents_OnComponetDrop;
    }

    private void OnDisable()
    {
        G004_GameEvents.OnTimerDestroyed -= G004_DragDropEvents_OnComponetDrop;
    }

    private void G004_DragDropEvents_OnComponetDrop()
    {
        NextInstruction();
    }

    private void NextInstruction()
    {
        instructionIndex++;
        RefreshInstructino();
    }

    private void RefreshInstructino()
    {
        shakeButton.SetActive(instructionIndex == shakeInsIndex);
        shacker.SetActive(instructionIndex != shakeInsIndex);
        shacketWithLid.SetActive(instructionIndex == shakeInsIndex);
        pourButton.SetActive(instructionIndex == pourButtonIndex);

        if (instructionIndex >= DB.steps.Count)
        {
            gameObject.SetActive(false);
            resultPanel.Result();
        }
        else
            text.text = DB.steps[instructionIndex].instruction;
        if (timerInstance)
            Destroy(timerInstance);

        if (instructionIndex < DB.steps.Count)
        {
            timerInstance = Instantiate(timer, transform.parent.transform);
            timerInstance.GetComponent<G004_Timer>().timeRemaining = DB.steps[instructionIndex].time;
            //timerInstance.GetComponent<G004_Timer>().timeRemaining = 2f;
        }
    }
}
