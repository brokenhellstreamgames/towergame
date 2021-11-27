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
            if (targetEntities.Count - 1 >= numberOfEntities)
            {
                Targets = targetEntities.Random(numberOfEntities).ToList<Entity>();
            }
            else
            {
                Targets = targetEntities.Random(targetEntities.Count - 1).ToList<Entity>();
            }
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
            if (targetEntities.Count - 1 >= numberOfEntities)
            {
                Targets = targetEntities.Random(numberOfEntities).ToList<Entity>();
            }
            else
            {
                Targets = targetEntities.Random(targetEntities.Count - 1).ToList<Entity>();
            }
        }
        if (Targets == null || Targets.Count == 0)
        {
            if (originEntity is Character)
            {
                Targets = GameManager.Instance.Enemies.Random(numberOfEntities).ToList<Entity>();
            }
            else
            {
                Targets = GameManager.Instance.Characters.Random(numberOfEntities).ToList<Entity>();
            }
        }
    }
}
