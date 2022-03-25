using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    public BulletModel _bulletModel
    {
        get;
    }
    public BulletView _bulletViewPrefab
    {
        get;
    }

    public BulletController(BulletModel bulletModel, BulletView bulletViewPrefab,TankController tankView)
    {
        _bulletModel = bulletModel;
       // _bulletViewPrefab = GameObject.Instantiate<BulletView>(bulletViewPrefab,tankView._tankViewPrefab.transform.position,Quaternion.identity);
        _bulletViewPrefab = ObjectPooling.Instance.ObjectToBeSpawnned("bullet",tankView._tankViewPrefab.transform.position, Quaternion.identity).GetComponent<BulletView>();
    }
    public BulletController(BulletModel bulletModel, BulletView bulletViewPrefab, TankView tankView)
    {
        _bulletModel = bulletModel;
        //_bulletViewPrefab = GameObject.Instantiate<BulletView>(bulletViewPrefab, tankView.gameObject.transform.position, Quaternion.identity);
        _bulletViewPrefab = ObjectPooling.Instance.ObjectToBeSpawnned("bullet", tankView.gameObject.transform.position, Quaternion.identity).GetComponent<BulletView>();
    }
    public BulletController(BulletModel bulletModel, BulletView bulletViewPrefab, EnemyTankController tankView)
    {
        _bulletModel = bulletModel;
        // _bulletViewPrefab = GameObject.Instantiate<BulletView>(bulletViewPrefab,tankView._tankViewPrefab.transform.position,Quaternion.identity);
        _bulletViewPrefab = ObjectPooling.Instance.ObjectToBeSpawnned("bullet", tankView._tankViewPrefab.transform.position, Quaternion.identity).GetComponent<BulletView>();
    }
    public BulletController(BulletModel bulletModel, BulletView bulletViewPrefab, EnemyTankView tankView)
    {
        _bulletModel = bulletModel;
        //_bulletViewPrefab = GameObject.Instantiate<BulletView>(bulletViewPrefab, tankView.gameObject.transform.position, Quaternion.identity);
        _bulletViewPrefab = ObjectPooling.Instance.ObjectToBeSpawnned("bullet", tankView.gameObject.transform.position, Quaternion.identity).GetComponent<BulletView>();
    }

    public void MoveBullet(TankView tankView)
    {
        _bulletViewPrefab.gameObject.GetComponent<Rigidbody>().velocity += tankView.Turret.transform.forward * _bulletModel.Speed;
    }

    public void MoveBullet(EnemyTankView tankView)
    {
        _bulletViewPrefab.gameObject.GetComponent<Rigidbody>().velocity += tankView._Turret.transform.forward * _bulletModel.Speed;
    }
}
