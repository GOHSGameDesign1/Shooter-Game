using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    public PlayerInputActions playerInputActions;
    public PlayerMovement playerMovement;
    public ShootingManager shootingManager;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerMovement.PlayerInput(this);
        shootingManager.PlayerInput(this);
        //StartCoroutine("wait");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {
        Debug.Log("5 seconds until disable");
        yield return new WaitForSeconds(5f);
        playerInputActions.Player.Disable();
        yield return new WaitForSeconds(5f);
        playerInputActions.Player.Enable();
        Debug.Log("Input restored");
    }
}
