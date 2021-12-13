using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Idle")]
public class IdleAction : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", true);
        //controller.SetAnimation("attack", true);
        controller.SetAnimation("shoot", false);
    }
}