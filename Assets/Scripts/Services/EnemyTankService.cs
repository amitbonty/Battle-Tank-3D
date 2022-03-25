using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : Singleton<EnemyTankService>
{

    [SerializeField]
    private EnemyTankView _tankView;
    [SerializeField]
    private TankTypes _type = TankTypes.None;
    [SerializeField]
    private TankScriptableObject[] _enemyTanks;
    private EnemyTankController _tankController;
    [SerializeField]
    private BulletTypes _bulletType = BulletTypes.None;
    [SerializeField]
    private BulletController bulletController;
    [SerializeField]
    private BulletView bulletView;
    [SerializeField]
    private float bulletSpeed;
    public List<TankController> enemyTanks;


    public void CreateEnemyTank()
    {
        int randomTank = Random.Range(0, 3);
        EnemyTankModel _tankModel = new EnemyTankModel(SpawnTank(randomTank).type, SpawnTank(randomTank).health, SpawnTank(randomTank).speed, SpawnTank(randomTank).damage);
        _tankController = new EnemyTankController(_tankModel, _tankView) ;
    }
    public void ChasePlayer(EnemyTankView tankViewPrefab)
    {
        if (GameObject.FindGameObjectWithTag("Player")&& Vector3.Distance(_tankController._tankViewPrefab.transform.position,GameObject.FindGameObjectWithTag("Player").transform.position)>=20f)
        {
            tankViewPrefab._navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }
    public void Shoot()
        {
            BulletModel _bulletModel = new BulletModel(_bulletType, bulletSpeed, 40);
            bulletController = new BulletController(_bulletModel, bulletView, _tankController);
            bulletController.MoveBullet(_tankController._tankViewPrefab);
        }
    private void Update()
    {
        SpawnEnemyTank();
    }
    
    public TankScriptableObject SpawnTank(int index)
    {
        return _enemyTanks[index];
    }
    public void SpawnEnemyTank()
    {
       if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            CreateEnemyTank();
        }
    }
}
