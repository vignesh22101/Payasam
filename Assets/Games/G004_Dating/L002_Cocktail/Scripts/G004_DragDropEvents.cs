using System;

public static class G004_DragDropEvents
{
    public static event Action<G004_Shaker.Component, bool> OnComponetDrop;

    public static void ComponentDropped(G004_Shaker.Component comp, bool isDestination)
    {
        OnComponetDrop?.Invoke(comp, isDestination);
    }
}

