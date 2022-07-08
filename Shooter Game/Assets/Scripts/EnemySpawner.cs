using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyPrefab;
    Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * (screenBounds.x + 4);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }
    }
}
