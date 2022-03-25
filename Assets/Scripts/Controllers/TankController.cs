using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel _tankModel
        {
        get;
        }
    public TankView _tankViewPrefab
    {
        get;
    }
    
   
    public TankController(TankModel tankModel,TankView tankViewPrefab)
    {
        _tankModel = tankModel;
        _tankViewPrefab = GameObject.Instantiate<TankView>(tankViewPrefab);
    }
    public void MoveTankForward(Joystick joyStick,float moveSpeed)
    {
        if (joyStick.Vertical > 0)
        {
            _tankViewPrefab.gameObject.transform.position += Vector3.forward * moveSpeed;
            _tankViewPrefab.Turret.transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

        }
        _tankViewPrefab.gameObject.transform.position += _tankViewPrefab.gameObject.transform.forward * moveSpeed;
        
      
    }
    public void MoveTankBackward(Joystick joyStick, float moveSpeed)
    {
        if (joyStick.Vertical < 0)
        {
            _tankViewPrefab.gameObject.transform.position += Vector3.back * moveSpeed;
            _tankViewPrefab.Turret.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
        }
        _tankViewPrefab.gameObject.transform.position -= _tankViewPrefab.gameObject.transform.forward * moveSpeed;
       

    }
    public void MoveTankRight(Joystick joyStick, float moveSpeed)
    {
        if (joyStick.Horizontal > 0)
        {
            _tankViewPrefab.gameObject.transform.position += Vector3.right * moveSpeed;
            _tankViewPrefab.Turret.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
        }
        _tankViewPrefab.gameObject.transform.position += _tankViewPrefab.gameObject.transform.right * moveSpeed;
      

    }
    public void MoveTankLeft(Joystick joyStick, float moveSpeed)
    {
        if (joyStick.Horizontal < 0)
        {
            _tankViewPrefab.gameObject.transform.position += Vector3.left* moveSpeed;
            _tankViewPrefab.Turret.transform.rotation = Quaternion.AngleAxis(270, new Vector3(0, 1, 0));

        }
        _tankViewPrefab.gameObject.transform.position -= _tankViewPrefab.gameObject.transform.right * moveSpeed;
        

    }
    public void SetHealth()
    {
        if(isAlive())
        {
            _tankViewPrefab.HealthBar.fillAmount = (float)_tankModel.Health / 100;
        }
       
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
