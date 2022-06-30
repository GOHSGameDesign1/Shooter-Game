using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float runSpeed;
    private GameObject player;
    Vector2 direction;
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
        //rb.velocity = direction.normalized * runSpeed;


    }

    private void FixedUpdate()
    {
        rb.velocity = direction.normalized * runSpeed;
    }
}
