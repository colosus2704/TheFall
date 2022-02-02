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
        //bool s = controller.GetInputS();
        bool g = controller.GetGround();
        if (/*s == false && */g == true)
        {
            a = true;
        }
        return a;
    }
}