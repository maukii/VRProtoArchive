using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Surfboard : XRGrabInteractable
{
    [SerializeField] private Transform sailRoot;
    [SerializeField] private Transform sailPivot;
    [SerializeField] private float maxSpeed = 25f;
    private Rigidbody rb;
    private XRController attachedController;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!attachedController)
            return;

        CalculateSailRotation();

        if (attachedController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float value))
        {
            ModifySpeed(attachedController, Mathf.Clamp01(value));
        }
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        attachedController = interactor.GetComponent<XRController>();        
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        attachedController = null;
    }
    
    private void CalculateSailRotation()
    {
        Vector3 end = attachedController.transform.position;
        Vector3 start = sailRoot.position;
        Vector3 direction = end - start;

        float signedAngle = Vector3.SignedAngle(end, sailRoot.transform.up, sailRoot.transform.forward);
        Debug.Log(signedAngle);

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        //transform.eulerAngles = transform.forward * angle;

        //Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, Time.deltaTime * 25f);
    }

    private void ModifySpeed(XRController controller, float value)
    {
        rb.velocity = transform.forward * maxSpeed * value;
    }
}
