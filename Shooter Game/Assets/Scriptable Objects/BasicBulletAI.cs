using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletAI/Basic")]
public class BasicBulletAI : BulletAI
{
    private Rigidbody2D rb;

    public override void Think(BulletBrain bullet)
    {
        rb = bullet.gameObject.GetComponent<Rigidbody2D>();
        bullet.Move();
    }

    public override void ThinkStart(BulletBrain bullet)
    {
        
    }

    public override void ThinkCollide(BulletBrain bullet)
    {
        bullet.EnemyHit();
    }
}
