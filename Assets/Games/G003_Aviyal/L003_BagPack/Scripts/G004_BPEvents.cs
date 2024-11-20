using System;

public static class G004_BPEvents
{
    public static event Action<G004_Backpack.Component, bool> OnComponetDrop;

    public static void ComponentDropped(G004_Backpack.Component comp, bool intoTheBag)
    {
        OnComponetDrop?.Invoke(comp, intoTheBag);
    }
}

