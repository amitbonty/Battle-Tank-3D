using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : TankStates
{
    [SerializeField]
    private float distanceVal=30f;
    private BulletTypes _bulletType = BulletTypes.None;
    [SerializeField]
    private BulletController bulletController;
    [SerializeField]
    private BulletView bulletView;
    [SerializeField]
    private float bulletSpeed;
    private float coolDown=0f;

    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("entered attack state");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Exited attack state");
    }
    public void Update()
    {
        coolDown+=Time.deltaTime;
        if(Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceVal&&coolDown>=5f)
        {
            BulletModel _bulletModel = new BulletModel(_bulletType, bulletSpeed, 40);
            bulletController = new BulletController(_bulletModel, bulletView, tankView);
            bulletController.MoveBullet(tankView);
            coolDown=0;
        }
        else
        {
            tankView.ChangeState(tankView._idleState);
        }
    }
}
