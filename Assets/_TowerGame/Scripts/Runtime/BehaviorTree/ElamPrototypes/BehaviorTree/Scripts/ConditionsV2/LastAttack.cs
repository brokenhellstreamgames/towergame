using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "LastAttack", menuName = "TowerGame/BehaviorTree/BehaviorConditions/LastAttack", order = 1)]
public class LastAttack : ConditionV2
{
    public override bool Check(Entity originEntity)
    {
        originEntity.BehaviorTree.items.ForEach(i => i.Enable());
        return true;
    }
}
