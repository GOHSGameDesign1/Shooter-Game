using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrain : MonoBehaviour
{

    public float bulletSpeed;
    public Rigidbody2D rb;
    Vector2 screenBounds;
    public BulletAI AI;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        AI.ThinkStart(this);
    }

    // Update is called once per frame
    void Update()
    {
        AI.Think(this);
    }

    private void FixedUpdate()
    {
        //rb.velocity = bulletSpeed * transform.right;

        Debug.Log(screenBounds.x);

        if (Mathf.Abs(transform.position.x) > screenBounds.x + 10)
        {
            Destroy(gameObject);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y + 10)
        {
            Destroy(gameObject);
        }
    }
}
