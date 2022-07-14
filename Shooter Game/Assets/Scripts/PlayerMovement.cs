using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    PlayerInputActions playerInputActionsMovement;
    public float runSpeed;
    private Vector2 inputVector;
    private bool isDashing;
    public float dashingFrames;
    private float currentDashingFrames;
    public float dashingSpeed;


    private void Awake()
    {

        isDashing = false;
        currentDashingFrames = dashingFrames;
    }

    void Movement_Performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);

    }

    void Dash_Performed(InputAction.CallbackContext context)
    {
        isDashing = true;
        //rb.MovePosition(rb.position + inputVector * dashingSpeed * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!isDashing) 
        { 
        inputVector = playerInputActionsMovement.Player.Movement.ReadValue<Vector2>().normalized;
        rb.MovePosition(rb.position + inputVector * runSpeed * Time.fixedDeltaTime);
        }
        else
        {
            currentDashingFrames--;
            rb.MovePosition(rb.position + inputVector * dashingSpeed * Time.fixedDeltaTime);
            if (currentDashingFrames <= 0)
            {
                isDashing = false;
                currentDashingFrames = dashingFrames;
            }
        }

    }

    public void PlayerInput(PlayerInputs playerInputs)
    {
        playerInputActionsMovement = playerInputs.playerInputActions;
        playerInputActionsMovement.Player.Dash.performed += Dash_Performed;
    }
}
