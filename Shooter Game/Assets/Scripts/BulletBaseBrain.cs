using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseBrain : MonoBehaviour
{
    public GameObject player;
    public GunScriptableObject currentGun;
    public Rigidbody2D rb;
    public float damage;
    public void GetCurrentGun()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentGun = player.GetComponent<ShootingManager>().currentGun;
        damage = currentGun.damage;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + (Vector2)transform.right.normalized * currentGun.bulletSpeed * Time.fixedDeltaTime);
    }

    public void Rotate(float angle)
    {
        rb.rotation += Random.Range(angle/2, angle/2 * -1);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void basicHit(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            return;
        }

        if(collision.gameObject.tag == "Bullet")
        {
            return;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().currentHealth -= damage;
            return;
        }

        Destroy(gameObject);
    }

    public IEnumerator LateDestroy()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("now destroying");
        Destroy(gameObject);
    }
}
