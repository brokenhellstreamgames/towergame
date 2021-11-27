using UnityEngine;

[CreateAssetMenu(fileName = "PowerBoostV2", menuName = "TowerGame/BehaviorTree/Modifiers/PowerBoostV2", order = 1)]
public class PowerBoostV2 : ModifierV2
{
    public override void ModifyAbility(AbilityInstance ability)
    {
        ability.Power = (int) (ability.Power * 1.2f);
    }
}