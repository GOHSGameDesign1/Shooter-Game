using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseBrain : MonoBehaviour
{
    public GameObject player;
    public GunScriptableObject currentGun;
    public Rigidbody2D rb;
    public void GetCurrentGun()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentGun = player.GetComponent<ShootingManager>().currentGun;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + (Vector2)transform.right.normalized * currentGun.bulletSpeed * Time.fixedDeltaTime);
    }

    public void Rotate(float angle)
    {
        rb.rotation += Random.Range(angle, angle * -1);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
