using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletBrain : BulletBaseBrain
{

    public float bulletSpeed;
    //public Rigidbody2D rb;
    public BulletAI AI;
    public float damage;
    //public GunScriptableObject currentGun;
    public GameObject currentCollidingEnemy;
    public ParticleSystem hitParticles;

    private void Awake()
    {
        GetCurrentGun();
        AI = currentGun.bulletAI;
        damage = currentGun.damage;
        Rotate(currentGun.inaccuracyAngle);
    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("Timeout");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.tag == "Enemy")
        {
            currentCollidingEnemy = collision.gameObject;
            AI.ThinkCollide(this);

        } else
        {
            Destroy(gameObject);
        }*/
    }

    public void EnemyHit()
    {
        if (currentCollidingEnemy != null)
        {
            //currentCollidingEnemy.GetComponent<EnemyHealth>().currentHealth -= damage;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(hitParticles, transform.position, transform.rotation);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
        else if(collision.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
