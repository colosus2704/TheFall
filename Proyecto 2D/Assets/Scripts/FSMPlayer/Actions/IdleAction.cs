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
        controller.SetAnimation("shoot", false);
        controller.SetAnimation("dash", false);
        controller.SetAnimation("jump", false);
    }
}