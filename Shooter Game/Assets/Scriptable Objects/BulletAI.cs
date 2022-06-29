using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAI : ScriptableObject
{
    public abstract void Think(BulletBrain bullet);

    public abstract void ThinkStart(BulletBrain bullet);
}
