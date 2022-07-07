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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //rb.velocity = direction.normalized * runSpeed;


    }

    private void FixedUpdate()
    {
        Vector2 repelForce = Vector2.zero;
        //rb.velocity = direction.normalized * runSpeed;

        foreach(GameObject enemy in enemies)
        {
            
            if (Vector2.Distance(enemy.transform.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - (Vector2)enemy.transform.position).normalized;
                repelForce += repelDir;
                //rb.AddForce(repelForce * 100);
            }
        }

        //rotate to player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        Vector2 newPos = rb.position + (Vector2)transform.right * runSpeed * Time.fixedDeltaTime;
        newPos += repelForce * Time.fixedDeltaTime; 
        rb.MovePosition(newPos);

    }
}
