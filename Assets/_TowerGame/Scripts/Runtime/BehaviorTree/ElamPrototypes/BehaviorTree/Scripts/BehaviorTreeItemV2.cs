using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Behavior Tree Item", menuName = "TowerGame/BehaviorTree/BehaviorTreeItem", order = 1)]
public class BehaviorTreeItemV2 : ScriptableObject
{
    // AbilityData contient les param�tres par d�fault d'une abilit�, notament le vfx et le targetPr�f�rence.
    // AbilityInstance est quand � lui cr�er � l'initalisation dans l'awake de Entity.
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
