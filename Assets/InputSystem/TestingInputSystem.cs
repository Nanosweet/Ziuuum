using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        


        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        
        playerInputActions.Player.Jump.performed += Jump;        
    }

    private void Update()
    {
        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("UI");
            playerInputActions.Player.Disable();
            playerInputActions.UI.Enable();

        }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("Player");
            playerInputActions.Player.Enable();
            playerInputActions.UI.Disable();
        }
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 1f;
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }   

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed)
        {
            Debug.Log("Jump!" + context.phase);
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        
    }
    public void Submit(InputAction.CallbackContext context)
    {
        Debug.Log("Submit" + context);
    }


}
