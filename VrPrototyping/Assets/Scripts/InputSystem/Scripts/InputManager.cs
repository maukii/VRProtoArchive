using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRController))]
public class InputManager : MonoBehaviour
{
    public List<ButtonHandler> allButtonHandlers = new List<ButtonHandler>();
    public List<AxisHandler2D> all2DAxisHandlers = new List<AxisHandler2D>();
    public List<AxisHandler> allAxisHandlers = new List<AxisHandler>();

    private XRController controller = null;


    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        HandleButtonEvents();
        HandleAxisEvents();
        HadnleAxis2DEvents();
    }

    private void HadnleAxis2DEvents()
    {
        foreach (AxisHandler2D handler in all2DAxisHandlers)
        {
            handler.HandleState(controller);
        }
    }

    private void HandleAxisEvents()
    {
        foreach (AxisHandler handler in allAxisHandlers)
        {
            handler.HandleState(controller);
        }
    }

    private void HandleButtonEvents()
    {
        foreach(ButtonHandler handler in allButtonHandlers)
        {
            handler.HandleState(controller);
        }
    }
}
