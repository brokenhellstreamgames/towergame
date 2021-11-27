using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "EmpowerReachedTreshold", menuName = "TowerGame/BehaviorTree/BehaviorConditions/EmpowerReachedTreshold", order = 1)]
public class EmpowerReachedTreshold : StatusEffectCondition
{
    public int StackTreshold;
    public override bool Check(Entity originEntity)
    {
        //bool alreadyTrue = false;
        if (originEntity.StatusEffects.ContainsKey(statusEffectKey))
        {
            if (originEntity.StatusEffects[statusEffectKey].CheckForStacks() > StackTreshold)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
