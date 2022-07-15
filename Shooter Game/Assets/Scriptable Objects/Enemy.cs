using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class Enemy : ScriptableObject
{
    public float health;
    public float moveSpeed;
    public float damage;
    public GameObject enemyPrefab;
    public float points;
    
}
