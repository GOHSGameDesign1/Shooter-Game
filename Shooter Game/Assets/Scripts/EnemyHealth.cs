using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    bool canCollide;

    //public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        canCollide = true;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if(collision.tag == "Bullet" && canCollide) Destroy(collision.gameObject);
            canCollide = false;
        }

        if (collision.tag == "Bullet" && canCollide)
        {            
            Destroy(collision.gameObject);
        }


    }
}
