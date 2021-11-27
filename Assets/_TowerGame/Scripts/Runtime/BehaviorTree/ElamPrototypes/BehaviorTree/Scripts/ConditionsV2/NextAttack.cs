using System.Collections;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NextAttack", menuName = "TowerGame/BehaviorTree/BehaviorConditions/NextAttack", order = 1)]
public class NextAttack : ConditionV2
{
    public override bool Check(Entity originEntity)
    {
        BehaviorTreeItemV2 itemV2 = originEntity.BehaviorTree.items.FirstOrDefault(i => !i.IsActive);
        if (itemV2 != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
