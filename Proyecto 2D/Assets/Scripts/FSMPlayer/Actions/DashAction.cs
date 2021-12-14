using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Dash")]
public class DashAction : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("shoot", false);
        controller.SetAnimation("dash", true);
        controller.SetAnimation("jump", false);
    }
}