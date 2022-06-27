using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "New Gun")]
public class GunScriptableObject : ScriptableObject
{
    public float fireRate;
    public float damage;
    public float Ammo;
    public Sprite gunSprite;
    public bool canAutoFire;
    public Vector3 fireCoordinates;

    //public abstract void BulletAI();
}
