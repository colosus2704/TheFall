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
        bool h = controller.GetInputW();
        bool s = controller.GetInputS();
        bool g = controller.GetGround();
        if (h == false && s == false && g)
        {
            a = true;
        }
        return a;
    }
}