using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class InputHandler : ScriptableObject
{
    public abstract void HandleState(XRController controller);
}
