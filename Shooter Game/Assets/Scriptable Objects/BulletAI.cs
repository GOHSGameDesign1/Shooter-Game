using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAI : ScriptableObject
{
    public abstract void Think(BulletBrain brain);
}
