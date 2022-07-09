using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletAI/Spread")]
public class SpreadBulletAI : BulletAI
{
    //private Rigidbody2D rb;
    public override void Think(BulletBrain bullet)
    {
        //rb = bullet.gameObject.GetComponent<Rigidbody2D>();

        //bullet.Move();
    }

    public override void ThinkStart(BulletBrain bullet)
    {
        //bullet.transform.Rotate(0, 0, Random.Range(-20, 20));
    }

    public override void ThinkCollide(BulletBrain bullet)
    {
        //bullet.EnemyHit();
    }
}
