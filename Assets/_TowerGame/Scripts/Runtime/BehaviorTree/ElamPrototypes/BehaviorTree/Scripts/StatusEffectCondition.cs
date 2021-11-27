using System.Collections;
using UnityEngine;

/// <summary>
/// Check if an entity is affected by the specified Status Effect, statusEffectKey must correspond to a existing statusKey.
/// </summary>
public class StatusEffectCondition : ConditionV2
{
    public string statusEffectKey;

    public override bool Check(Entity originEntity)
    {
        throw new System.NotImplementedException();
    }
}