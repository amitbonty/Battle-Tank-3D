using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletModel
{
    public float Speed
    {
        get;
    }
   
    public int Damage
    {
        get;
    }
    public BulletTypes Type
    {
        get;
    }
    public BulletModel(BulletTypes type, float speed, int damage)
    {
        Speed = speed;
        Type = type;
        Damage = damage;
    }
}
