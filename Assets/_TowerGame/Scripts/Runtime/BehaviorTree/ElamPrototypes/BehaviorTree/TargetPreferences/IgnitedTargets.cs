using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IgnitedTargets", menuName = "TowerGame/BehaviorTree/TargetPreferences/IgnitedTargets", order = 1)]
public class IgnitedTargets : TargetPreferenceV2
{
    public string StatusEffectKey;
    public override void ComputeEntities(int numberOfEntities, Entity originEntity)
    {
        List<Entity> targetEntities = new List<Entity>();
        if (originEntity is Character)
        {
            foreach (var entity in GameManager.Instance.Enemies)
            {
                if (entity.StatusEffects.ContainsKey(StatusEffectKey))
                {
                    targetEntities.Add(entity);
                }
            }
            Targets = targetEntities.Random(numberOfEntities).ToList<Entity>();
        }
        else
        {
            foreach (var entity in GameManager.Instance.Characters)
            {
                if (entity.StatusEffects.ContainsKey(StatusEffectKey))
                {
                    targetEntities.Add(entity);
                }
            }
            Targets = targetEntities.Random(numberOfEntities).ToList<Entity>();
        }
    }
}
