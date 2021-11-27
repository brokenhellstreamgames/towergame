using UnityEngine;

[CreateAssetMenu(fileName = "PhysicalAttackV2", menuName = "TowerGame/BehaviorTree/Modifiers/PhysicalAttackV2", order = 1)]
public class PhysicalAttackV2 : ModifierV2
{
    public override void ModifyAbility(AbilityInstance ability)
    {
        ability.Type = AbilityType.Physic;
    }
}