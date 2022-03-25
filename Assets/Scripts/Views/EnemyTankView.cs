using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    [SerializeField]
    private GameObject _turret;
    [SerializeField]
    private Image _healthBar;
    public EnemyTankController _enemyTankController;
    
    public Image _HealthBar
    {
        get;
        set;
    }
   
    public GameObject _Turret
    {
        get;
        set;
    }

    [SerializeField]
    public TankStates _currentState;

    [SerializeField]
    public TankStates _idleState;

    [SerializeField]
    public TankStates _chaseState;

    [SerializeField]
    public TankStates _attackState;
    [SerializeField]
    public NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        this._Turret = _turret;
        _HealthBar = _healthBar;
    }
    private void Start() {
        if(!gameObject.CompareTag("Player") && isActiveAndEnabled)
        {
            ChangeState(_idleState);
        } 
    }
    public void ChangeState(TankStates tankState)
    {
        if (_currentState != null)
        {
            _currentState.OnExitState();
        }
        _currentState = tankState;
        _currentState.OnEnterState();
    }
    public void GetReferenceToController(EnemyTankController enemyTankController)
    {
        _enemyTankController = enemyTankController;
    }
    private void Update() {
        if(_enemyTankController.isAlive())
        {
            _enemyTankController.SetHealth();
        }
        else if(!_enemyTankController.isAlive())
        {
           Destroy(_enemyTankController._tankViewPrefab.gameObject) ;
           GameManager.Instance._score++;
        }
       
    }

}
