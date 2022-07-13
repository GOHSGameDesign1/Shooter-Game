using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplodeAI : BulletBaseBrain
{
    public ParticleSystem hitParticles;
    public GameObject explosionBulletPrefab;

    private void Awake()
    {
        GetCurrentGun();
        //Rotate(currentGun.inaccuracyAngle);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timeout");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            return;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(LateDestroy());
        }
    }

    private void OnDestroy()
    {
        Instantiate(hitParticles, transform.position, transform.rotation);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(explosionBulletPrefab, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Random.Range(0, 359)));
        }
    }
}
