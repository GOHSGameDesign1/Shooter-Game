using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletAI/Wiggle")]
public class WiggleAI : BulletAI
{

    private Rigidbody2D rb;
    public float bulletSpeed;
    public override void Think(BulletBrain bullet)
    {
        rb = bullet.gameObject.GetComponent<Rigidbody2D>();
        bullet.transform.Rotate(0, 0, Random.Range(-20, 20));
        rb.velocity = bullet.gameObject.transform.right * bulletSpeed;
    }

    public override void ThinkStart(BulletBrain bullet)
    {

    }
}
