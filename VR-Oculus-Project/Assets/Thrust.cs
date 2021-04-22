using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class Thrust : MonoBehaviour
{
    [SerializeField] Rigidbody optRigidbody;
    [SerializeField] CharacterController optCharController;

    void Update()
    {/*
        if (action.phase != InputActionPhase.Waiting)
        {
            ApplyThrust();
        }*/
    }

    InputAction action;
    // Update is called once per frame
    public void OnGrab(InputAction.CallbackContext ctx)
    {
        action = ctx.action.actionMap.FindAction("triggerpress");
    }

    [SerializeField] float thrustAccel = 10f;
    public void ApplyThrust()
    {
            optCharController?.Move(transform.up * thrustAccel);
    }
}
