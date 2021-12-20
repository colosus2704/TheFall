using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/IdleDecision")]
public class IdleDecision : FSM.Decision
{

    private bool a = false;

    public override bool Decide(Controller controller)
    {
        float h = controller.GetInput();
        bool g = controller.GetGround();
        if (h == 0)
        {
            a = true;
        }
        return a;
    }
}