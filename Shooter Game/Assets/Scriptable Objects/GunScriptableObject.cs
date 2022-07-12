using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "New Gun")]
public class GunScriptableObject : ScriptableObject
{
    public float fireRate;
    public float damage;
    public float Ammo;
    public float ReloadTime;
    public float inaccuracyAngle;
    public bool canAutoFire;
    public float bulletSpeed;
    public float bulletsShotAtOnce;
    public float spreadAngleRange;
    public GameObject bulletPrefab;

    public Sprite gunSprite;
    public Vector3 fireCoordinates;
    //public abstract void BulletAI();
}
