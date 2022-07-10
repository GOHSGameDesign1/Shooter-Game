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
    public Sprite gunSprite;
    public bool canAutoFire;
    public Vector3 fireCoordinates;
    public float bulletSpeed;
    public float bulletsShotAtOnce;

    //public abstract void BulletAI();
}
