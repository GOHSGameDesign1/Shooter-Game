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
    public ShootingManager shootingManager;


    private void Awake()
    {
        //playerInputActions = new PlayerInputActions();
        //playerInputActions.Player.Enable();
        //playerInputActions.Player.Movement.performed += Movement_Performed;
       // playerInputActions.Player.Dash.performed += Dash_Performed;

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
        rb.velocity = inputVector * dashingSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDashing) 
        { 
        inputVector = playerInputActionsMovement.Player.Movement.ReadValue<Vector2>();
        rb.velocity = inputVector * runSpeed;
        }
        else
        {
            currentDashingFrames--;
            if(currentDashingFrames <= 0)
            {
                isDashing = false;
                currentDashingFrames = dashingFrames;
            }
        }

        //shootingManager.player(this);
    }

    public void PlayerInput(PlayerInputs playerInputs)
    {
        playerInputActionsMovement = playerInputs.playerInputActions;
        playerInputActionsMovement.Player.Dash.performed += Dash_Performed;
    }
}
