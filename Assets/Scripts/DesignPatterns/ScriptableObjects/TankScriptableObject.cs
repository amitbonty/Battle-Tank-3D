using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TankScriptableObject",menuName ="ScriptableObjects/NewTank") ]
public class TankScriptableObject:ScriptableObject
{
    public int health;
    public int damage;
    public float speed;
    public TankTypes type;
    public string tankName;
}
