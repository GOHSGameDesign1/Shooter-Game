using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletBrain : MonoBehaviour
{

    public float bulletSpeed;
    public Rigidbody2D rb;
    Vector2 screenBounds;
    public BulletAI AI;
    public float damage;
    public GunScriptableObject currentGun;
    public GameObject currentCollidingEnemy;
    public ParticleSystem hitParticles;

    private void Awake()
    {
        //AI = currentGun.bulletAI;
        //damage = currentGun.damage;
    }

    // Start is called before the first frame update
    void Start()
    {

        AI = currentGun.bulletAI;
        damage = currentGun.damage;
        bulletSpeed = currentGun.bulletSpeed;
        AI.ThinkStart(this);

        StartCoroutine("Timeout");
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        AI.Think(this);
    }

    private void FixedUpdate()
    {
        //rb.velocity = bulletSpeed * transform.right;
        /* Debug.Log(screenBounds);

         if (Mathf.Abs(transform.position.x) > screenBounds.x + 10)
         {
             Destroy(gameObject);
         }

         if (Mathf.Abs(transform.position.y) > screenBounds.y + 10)
         {
             Destroy(gameObject);
         }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentCollidingEnemy = collision.gameObject;
            AI.ThinkCollide(this);

        } else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyHit()
    {
        if (currentCollidingEnemy != null)
        {
            currentCollidingEnemy.GetComponent<EnemyHealth>().currentHealth -= damage;
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        //rb.velocity = transform.right * bulletSpeed;
        rb.MovePosition(rb.position + (Vector2)transform.right.normalized * bulletSpeed * Time.fixedDeltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(hitParticles, transform.position, transform.rotation);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentCollidingEnemy = collision.gameObject;
            AI.ThinkCollide(this);

        }
        else if(collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
}
