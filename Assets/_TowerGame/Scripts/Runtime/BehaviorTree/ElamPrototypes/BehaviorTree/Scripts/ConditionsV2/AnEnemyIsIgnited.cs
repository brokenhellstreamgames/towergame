using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIsIgnitedCondition", menuName = "TowerGame/BehaviorTree/BehaviorConditions/EnemyIsIgnited", order = 1)]
public class AnEnemyIsIgnited : StatusEffectCondition
{
    public override bool Check(Entity originEntity)
    {
        //bool alreadyTrue = false;
        var igniteInstance = new Ignite();
        if (originEntity is Character)
        {
            foreach (var entity in GameManager.Instance.Enemies)
            {
                if (entity.StatusEffects.ContainsKey(igniteInstance.StatusKey))
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            foreach (var entity in GameManager.Instance.Characters)
            {
                if (entity.StatusEffects.ContainsKey(igniteInstance.StatusKey))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
