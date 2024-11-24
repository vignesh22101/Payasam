using System;

public static class G004_GameEvents
{
    public static event Action OnSubmit, OnFailed, OnSuccess, OnTimerDestroyed;

    public static void SubmitGame()
    {
        OnSubmit?.Invoke();
    }

    public static void GameFailed()
    {
        OnFailed?.Invoke();
    }

    public static void GameSuccess()
    {
      OnSuccess?.Invoke();
    }

    public static void TimerDestro()
    {
        OnTimerDestroyed?.Invoke();
    }
}

