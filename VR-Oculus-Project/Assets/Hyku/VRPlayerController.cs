using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class VRPlayerController : MonoBehaviour
{
    [SerializeField] InputActionAsset actions;
    InputAction jumpAction;
    [SerializeField] float jumpForce = 500f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = actions.FindAction("Jump");
        jumpAction.performed += Jump;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
}
