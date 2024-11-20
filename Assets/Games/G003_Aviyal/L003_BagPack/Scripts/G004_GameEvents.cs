using System;

public static class G004_GameEvents
{
    public static event Action OnSubmit, OnFailed, OnSuccess;

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
}

