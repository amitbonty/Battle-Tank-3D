using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public float Speed
    {
        get;
    }
    public int Health
    {
        get;
        set;
    }
    public int Damage
    {
        get;
    }
    public TankTypes Type
    {
        get;
    }
    
    public TankModel(TankTypes type,int health,float speed,int damage)
    {
        Speed = speed;
        Health = health;
        Type = type;
        Damage = damage;
    }
}
