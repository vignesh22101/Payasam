using System;

public static class G003_DragDropEvents
{
    public static event Action<G003_Backpack.Component, bool> OnComponetDrop;

    public static void ComponentDropped(G003_Backpack.Component comp, bool isDestination)
    {
        OnComponetDrop?.Invoke(comp, isDestination);
    }
}

