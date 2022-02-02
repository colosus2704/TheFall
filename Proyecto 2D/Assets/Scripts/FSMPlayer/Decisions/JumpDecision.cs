using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/JumpDecision")]
public class JumpDecision : FSM.Decision
{

    private bool wPressed = false;

    public override bool Decide(Controller controller)
    {
        bool h = controller.GetInputW();
        bool g = controller.GetGround();
        if (h == true && g == true)
        {
            wPressed = true;
        }
        else
        {
            wPressed = false;
        }
        return wPressed; 
    }
}