using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingManager : MonoBehaviour
{
    public GunScriptableObject currentGun;
    private SpriteRenderer spriteRenderer;
    private Vector2 direction;
    Vector2 mousePos;
    Transform firePoint;
    Transform gunHolder;
    PlayerInputActions playerInputActionsShooting;
    GameObject currentBullet;
    public GameObject bullet;  //will change this to get from scriptable object later
    bool offCooldown = true;
    float shooting;
    


    private void Awake()
    {
        gunHolder = transform.Find("Gun_Holder");
        spriteRenderer = gunHolder.gameObject.GetComponent<SpriteRenderer>();
        firePoint = transform.Find("Gun_Holder/Fire_Point");
        firePoint.transform.position = currentGun.fireCoordinates;
        spriteRenderer.sprite = currentGun.gunSprite;

        //shooting = new PlayerInputActions();
        //shooting.Player.Enable();
        //shooting.Player.Fire.performed += Fire_Performed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(playerInputActionsShooting.Player.Fire.ReadValue<float>());
    }

    private void FixedUpdate()
    {
        direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunHolder.transform.rotation = Quaternion.Euler(0, 0, angle);

        shooting = playerInputActionsShooting.Player.Fire.ReadValue<float>();

        //Code for flipping the around when pointing at certain angles
        if (gunHolder.transform.rotation.eulerAngles.z > 90f && gunHolder.transform.rotation.eulerAngles.z < 270f)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }

        if (shooting == 1 && currentGun.canAutoFire && offCooldown)
        {
            offCooldown = false;

            Shoot();

            StartCoroutine("Cooldown");
        }
    }

    void Fire_Performed(InputAction.CallbackContext context)
    {
        if (!currentGun.canAutoFire && offCooldown) 
        {
            offCooldown = false;

            Shoot();

            StartCoroutine("Cooldown");
        }
    }

    public void PlayerInput(PlayerInputs playerInputs)
    {
        playerInputActionsShooting = playerInputs.playerInputActions;
        playerInputActionsShooting.Player.Fire.performed += Fire_Performed;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(currentGun.fireRate);
        offCooldown = true;
    }

    void Shoot()
    {
        for(int i = 0; i < currentGun.bulletsShotAtOnce; i++)
        {
            currentBullet = Instantiate(bullet, firePoint.transform.position, gunHolder.transform.rotation);
            currentBullet.GetComponent<BulletBrain>().AI = currentGun.bulletAI;
        }
    }
}
