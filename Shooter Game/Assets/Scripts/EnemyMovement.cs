using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float runSpeed;
    private GameObject player;
    Vector2 direction;
    public GameObject[] enemies;
    public float repelRange;
    Vector2 repelForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //rb.velocity = direction.normalized * runSpeed;


    }

    private void FixedUpdate()
    {
        //rb.velocity = direction.normalized * runSpeed;

        foreach(GameObject enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, rb.position) <= repelRange)
            {
                repelForce += (rb.position - (Vector2)enemy.transform.position).normalized;
            }
        }
        rb.MovePosition(rb.position + direction.normalized * runSpeed * Time.fixedDeltaTime + (repelForce * Time.fixedDeltaTime));
    }
}
