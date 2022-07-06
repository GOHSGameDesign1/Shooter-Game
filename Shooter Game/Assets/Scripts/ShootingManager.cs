using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

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
    float Ammo;
    public float currentAmmo;
    bool hasAmmo;
    bool reloading;

    //UI
    //public TMP_Text currentAmmoText;
    public TMP_Text AmmoText;
    public Image reloadBar;
    


    private void Awake()
    {
        gunHolder = transform.Find("Gun_Holder");
        spriteRenderer = gunHolder.gameObject.GetComponent<SpriteRenderer>();
        firePoint = transform.Find("Gun_Holder/Fire_Point");
        firePoint.transform.position = currentGun.fireCoordinates;
        spriteRenderer.sprite = currentGun.gunSprite;
        Ammo = currentGun.Ammo;
        currentAmmo = Ammo;
        hasAmmo = true;
        reloadBar.fillAmount = 0f;
        //shooting = new PlayerInputActions();
        //shooting.Player.Enable();
        //shooting.Player.Fire.performed += Fire_Performed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(playerInputActionsShooting.Player.Fire.ReadValue<float>());


        Ammo = currentGun.Ammo;
        AmmoText.text = currentAmmo.ToString() + " / " + currentGun.Ammo.ToString();

        //ReloadBarFiller();
        //currentAmmoText.text = currentAmmo.ToString();
    }

    private void FixedUpdate()
    {
        direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunHolder.transform.rotation = Quaternion.Euler(0, 0, angle);

        shooting = playerInputActionsShooting.Player.Fire.ReadValue<float>();


        if(currentAmmo <= 0) 
        { 
            hasAmmo = false;
        }

        //Code for flipping the around when pointing at certain angles
        if (gunHolder.transform.rotation.eulerAngles.z > 90f && gunHolder.transform.rotation.eulerAngles.z < 270f)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }

        if (shooting == 1 && currentGun.canAutoFire && offCooldown && hasAmmo)
        {
            offCooldown = false;

            Shoot();

            StartCoroutine("Cooldown");
        }
    }

    void Fire_Performed(InputAction.CallbackContext context)
    {
        if (!currentGun.canAutoFire && offCooldown && hasAmmo)
        {
            offCooldown = false;

            Shoot();

            StartCoroutine("Cooldown");
        }


    }

    void Reload_Performed(InputAction.CallbackContext context)
    {
        if(context.control.name == "r")
        {
            if(currentAmmo != Ammo && !reloading)
            {
                StartCoroutine("Reload");
                StartCoroutine("ReloadUIBar");
            }
        }

        if(context.control.name == "leftButton")
        {
            if(currentAmmo <= 0 && !reloading)
            {
                StartCoroutine("Reload");
                StartCoroutine("ReloadUIBar");
            }
        }
    }

    //This gets input from the playerInput script
    public void PlayerInput(PlayerInputs playerInputs)
    {
        playerInputActionsShooting = playerInputs.playerInputActions;
        playerInputActionsShooting.Player.Fire.performed += Fire_Performed;
        playerInputActionsShooting.Player.Reload.performed += Reload_Performed;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(currentGun.fireRate);
        offCooldown = true;
    }

    IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(currentGun.ReloadTime);
        currentAmmo = Ammo;
        hasAmmo = true;
        reloading = false;
        Debug.Log("Reloaded!");
    }



    void Shoot()
    {
        for(int i = 0; i < currentGun.bulletsShotAtOnce; i++)
        {
            currentBullet = Instantiate(bullet, firePoint.transform.position, gunHolder.transform.rotation);
            currentBullet.GetComponent<BulletBrain>().AI = currentGun.bulletAI;
            currentBullet.GetComponent<BulletBrain>().currentGun = currentGun;
        }

        currentAmmo--;
    }

    void ReloadBarFiller()
    {
        reloadBar.fillAmount = currentAmmo / Ammo;
    }

    IEnumerator ReloadUIBar()
    {
        reloadBar.fillAmount = 1;
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(currentGun.ReloadTime/5);
            reloadBar.fillAmount -= 0.2f;
        }
    }
}
