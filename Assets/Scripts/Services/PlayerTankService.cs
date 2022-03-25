using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTankService : Singleton<PlayerTankService>
{

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private FixedJoystick _joyStick;
    [SerializeField]
    private TankView _tankView;
    [SerializeField]
    private BulletView _bulletView;
    [SerializeField]
    private TankTypes _type = TankTypes.None;
    [SerializeField]
    private BulletTypes _bulletType = BulletTypes.None;
    [SerializeField]
    private float _bulletSpeed=0.3f;
    private int count;
    private GameObject[] GameWorld;
    private BulletController _bulletController;
    private TankController _tankController;
    public int _bulletCount;
   

    private void Start()
    {
        TankModel _tankModel = new TankModel(_type, 100, 3, 40);
        _tankController = new TankController(_tankModel, _tankView);
        GameWorld = GameObject.FindGameObjectsWithTag("Game");
        EventsSystem.Instance.OnBulletsFired += CheckCount;
    }
    
    private void Update()
    {
        if(_tankController!=null)
        {
        _tankController.SetHealth();
        MoveTank(_tankController);
        FireBullet();
        TakeDamage(_tankController, 20);
        }
        AnimeStyleDeath(); 
    }

    public void MoveTank(TankController tankController)
    {
        tankController.MoveTankForward(_joyStick, _moveSpeed);
        tankController.MoveTankBackward(_joyStick, _moveSpeed);
        tankController.MoveTankRight(_joyStick, _moveSpeed);
        tankController.MoveTankLeft(_joyStick, _moveSpeed);
    }
    public void FireBullet()
    {
        if(_bulletController==null&&Input.GetKeyDown(KeyCode.Space))
        {
         BulletModel _bulletModel = new BulletModel(_bulletType, _bulletSpeed, 40);
        _bulletController = new BulletController(_bulletModel, _bulletView, _tankController);
        _bulletController.MoveBullet(_tankController._tankViewPrefab);
        Coroutine bulletCoroutine =StartCoroutine(DestroyBullet(_bulletController));
        _bulletCount++;
        EventsSystem.Instance.OnBulletsFired();

        }
    }
    
    public void CheckCount()
    {
        if (_bulletCount == 10)
        {
            StartCoroutine(AchievementSystem.Instance.ShowPopup1());
        }
        else if (_bulletCount == 15)
        {
            StartCoroutine(AchievementSystem.Instance.ShowPopup2());
        }
        else if (_bulletCount == 20)
        {
            StartCoroutine(AchievementSystem.Instance.ShowPopup3());
        }
    }

    
    IEnumerator DestroyBullet(BulletController bulletController)
    {
        yield return new WaitForSeconds(3f);
        // Destroy(bulletController._bulletViewPrefab.gameObject);
        bulletController._bulletViewPrefab.gameObject.SetActive(false);
        _bulletController = null;
    }
    public void AnimeStyleDeath()
    {
        if (_tankController==null)
        {
            StartCoroutine(Death1());
        }
    }
    IEnumerator Death1()
    {
        Destroy(GameWorld[0]);
        yield return new WaitForSeconds(1f);
        yield return Death2();
        yield return Death3();
        yield return Death4();
        yield return Death5();
    }
    IEnumerator Death2()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GameWorld[1]);
    }
    IEnumerator Death3()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GameWorld[2]);
    }
    IEnumerator Death4()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GameWorld[3]);
    }
    IEnumerator Death5()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GameWorld[4]);
    }

    public void TakeDamage(TankController tankcontroller,int dmg)
    {
        Debug.Log("Tank health is " + tankcontroller._tankModel.Health);
        if(Input.GetKeyDown(KeyCode.A))
        {
            tankcontroller._tankModel.Health -= dmg;
            if(tankcontroller._tankModel.Health<0)
            {
                Destroy(_tankController._tankViewPrefab.gameObject);
                _tankController = null;
            }
        }
    }
    private void OnDisable() {
        EventsSystem.Instance.OnBulletsFired -= CheckCount;
    }



}
