using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstAttackV2", menuName = "TowerGame/BehaviorTree/BehaviorConditions/FirstAttackV2", order = 1)]
public class FirstAttackV2 : ConditionV2
{
    public override bool Check(Entity originEntity)
    {
        BehaviorTreeItemV2 itemV2 = originEntity.BehaviorTree.items.FirstOrDefault(i => !i.IsActive);
        if (itemV2 == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
