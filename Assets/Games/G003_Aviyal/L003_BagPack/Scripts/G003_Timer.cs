using TMPro;
using UnityEngine;

public class G003_Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Set the timer duration in seconds
    public bool isCountdown = true;  // Set to true for countdown, false for stopwatch
    public TextMeshProUGUI timerText;          // UI Text to display the timer (optional)

    private bool timerRunning = false;

    void Start()
    {
        timerRunning = true; // Start the timer when the game starts
    }

    void Update()
    {
        if (timerRunning)
        {
            if (isCountdown)
            {
                // Countdown
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    UpdateTimerDisplay(timeRemaining);
                }
                else
                {
                    timeRemaining = 0;
                    timerRunning = false;
                    TimerEnded();
                }
            }
            else
            {
                // Stopwatch
                timeRemaining += Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timerText != null && timeToDisplay >= 0)
        {
            // Format time as minutes and seconds (e.g., 01:23)
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = seconds + "s";
            //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void TimerEnded()
    {
        Debug.Log("Timer ended!");
        //timerText.text = "0s";
        AutoSubmit();
    }

    private void AutoSubmit()
    {
        G004_GameEvents.SubmitGame();
    }

    public void StartTimer(float duration, bool countdown = true)
    {
        timeRemaining = duration;
        isCountdown = countdown;
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer(float newDuration)
    {
        timeRemaining = newDuration;
        timerRunning = false;
        UpdateTimerDisplay(timeRemaining);
    }
}
