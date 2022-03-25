using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankStates : MonoBehaviour
{
    protected EnemyTankView tankView;
    protected Transform player;
    protected EnemyTankController tankController;
    private void Awake()
    {
        tankView = GetComponent<EnemyTankView>();
    }

    private void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }
    public virtual void Tick()
    {
        
    }
}
