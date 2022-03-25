using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : TankStates
{
    [SerializeField]
     private float distanceVal;
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entered Chase state");

        gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
    
    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Exited Chase state");
       // gameObject.GetComponent<NavMeshAgent>().isStopped=true;
    }

    private void Update() {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= distanceVal)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
        else
        {
           // gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            tankView.ChangeState(tankView._attackState);
        }
    }
}
