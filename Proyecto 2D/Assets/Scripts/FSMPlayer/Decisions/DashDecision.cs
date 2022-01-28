using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/DashDecision")]
public class DashDecision : FSM.Decision
{
    protected InputSystemKeyboard _inputSystemKeyboard;

    private bool sPressed = false;

    public override bool Decide(Controller controller)
    {
        bool h = controller.GetInputS();
        if (h == true)
        {
            sPressed = true;
        }
        else
        {
            sPressed = false;
        }
        return sPressed;
    }
}
