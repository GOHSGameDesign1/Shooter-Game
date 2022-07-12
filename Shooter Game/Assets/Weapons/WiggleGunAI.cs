using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : BulletBaseBrain
{
    public ParticleSystem hitParticles;

    private void Awake()
    {
        GetCurrentGun();

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timeout");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate(currentGun.inaccuracyAngle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        basicHit(collision);
    }

    private void OnDestroy()
    {
        Instantiate(hitParticles, transform.position, transform.rotation);
    }
}
