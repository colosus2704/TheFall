using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/JumpDecision")]
public class JumpDecision : FSM.Decision
{
    protected InputSystemKeyboard _inputSystemKeyboard;

    private bool wPressed = false;

    public override bool Decide(Controller controller)
    {
        float h = controller.GetInput();
        if (h > 0)
        {
            wPressed = true;
        }
        return wPressed; 
    }
}