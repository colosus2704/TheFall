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
        float h = controller.GetInput();
        if (h < 0)
        {
            sPressed = true;
        }
        return sPressed;
    }
}
