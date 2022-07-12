using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NormalBulletAI : BulletBaseBrain
{
    public ParticleSystem hitParticles;

    private void Awake()
    {
        GetCurrentGun();
        Rotate(currentGun.inaccuracyAngle);
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
        basicHit(collision);
    }

    private void OnDestroy()
    {
        Instantiate(hitParticles, transform.position, transform.rotation);
    }
}
