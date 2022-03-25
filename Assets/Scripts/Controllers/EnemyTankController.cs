using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    public EnemyTankModel _tankModel
    {
        get;
    }
    public EnemyTankView _tankViewPrefab
    {
        get;
    }
    public EnemyTankController(EnemyTankModel tankModel,EnemyTankView tankViewPrefab)
    {
        _tankModel = tankModel;
        _tankViewPrefab = GameObject.Instantiate<EnemyTankView>(tankViewPrefab);
        _tankViewPrefab.GetReferenceToController(this);
    }
    
    public void SetHealth()
    {
        _tankViewPrefab._HealthBar.fillAmount = (float)_tankModel.Health / 100;
    }

    public bool isAlive()
    {
        return _tankModel.Health > 0;
    }

    public void TakeDamage(int dmg)
    {
        _tankModel.Health -= dmg;
    }
}
