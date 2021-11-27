using UnityEngine;

[CreateAssetMenu(fileName = "MagicalAttackV2", menuName = "TowerGame/BehaviorTree/Modifiers/MagicalAttackV2", order = 1)]
public class MagicalAttackV2 : ModifierV2
{
    public override void ModifyAbility(AbilityInstance ability)
    {
        ability.Type = AbilityType.Magic;
    }
}