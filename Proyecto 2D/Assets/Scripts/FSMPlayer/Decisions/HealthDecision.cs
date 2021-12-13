using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/HealthDecision")]
public class HealthDecision : FSM.Decision
{
    public int healthLimitMin, healthLimitMax;
    
    public override bool Decide(Controller controller)
    {
        int h = controller.GetCurrentHealth();
        bool t = (h > healthLimitMin && h < healthLimitMax);
        return t;
    }
}