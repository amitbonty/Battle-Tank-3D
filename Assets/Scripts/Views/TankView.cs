using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TankView : MonoBehaviour
{
    [SerializeField]
    private GameObject turret;
    [SerializeField]
    private Image healthBar;

    
    
    public Image HealthBar
    {
        get;
        set;
    }
   
    public GameObject Turret
    {
        get;
        set;
    }
    private void Awake()
    {
        this.Turret = turret;
        HealthBar = healthBar;
    }

    
}
