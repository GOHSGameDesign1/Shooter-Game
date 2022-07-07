using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * 23;
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
