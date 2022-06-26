using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GunScriptableObject currentGun;
    private SpriteRenderer spriteRenderer;
    private Vector2 direction;
    public Camera cam;
    Vector2 mousePos;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = currentGun.gunSprite;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    private void FixedUpdate()
    {
        direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(transform.rotation.eulerAngles.z > 90f && transform.rotation.eulerAngles.z < 270f)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}
