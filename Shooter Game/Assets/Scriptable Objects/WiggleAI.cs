using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletAI/Wiggle")]
public class WiggleAI : BulletAI
{

    //private Rigidbody2D rb;
    public override void Think(BulletBrain bullet)
    {
        //rb = bullet.gameObject.GetComponent<Rigidbody2D>();
        //bullet.transform.Rotate(0, 0, Random.Range(-20, 20));
        //bullet.Move();
    }

    public override void ThinkStart(BulletBrain bullet)
    {

    }

    public override void ThinkCollide(BulletBrain bullet)
    {
        //bullet.EnemyHit();
    }
}
