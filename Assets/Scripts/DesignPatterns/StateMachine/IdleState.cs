using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : TankStates
{
   float timeTaken = 0f;
    
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entered Idle State!");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Exited Idle State!");
    }
    public void Update()
    {
        timeTaken += Time.deltaTime;
        if(timeTaken>=5f)
        {
            tankView.ChangeState(tankView._chaseState);
        }
        
    }
}
