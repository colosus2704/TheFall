using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Jump")]
public class JumpAction : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("shoot", false);
        controller.SetAnimation("dash", false);
        controller.SetAnimation("jump", true);
    }
}