using System.Collections;
using UnityEngine;

public class ProcessedActionData
{
    public ActionData ActionData { get; private set; }
    public BattleCharacterController Target { get; private set; }

    public ProcessedActionData(ActionData actionData, BattleCharacterController target)
    {
        ActionData = actionData;
        Target = target;
    }

}
