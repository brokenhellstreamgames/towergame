using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Behavior Tree Item", menuName = "TowerGame/BehaviorTree/BehaviorTreeItem", order = 1)]
public class BehaviorTreeItemV2 : ScriptableObject
{
    // AbilityData contient les paramètres par défault d'une abilité, notament le vfx et le targetPréférence.
    // AbilityInstance est quand à lui créer à l'initalisation dans l'awake de Entity.
    public List<ConditionV2> Conditions;
    public AbilityData abilityData;
    public AbilityInstance Ability;
    public ModifierV2 Modifier;

    public bool IsActive;

    public void Initialize()
    {
        Ability = new AbilityInstance(abilityData);
    }

    public void Enable()
    {
        IsActive = true;
    }

    public void Disable()
    {
        IsActive = false;
    }

    public bool CheckConditions(Entity originEntity)
    {
        foreach (var item in Conditions)
        {
            if (item.Check(originEntity))
            {
                return true;
            }
        }
        return false;
    }


}
