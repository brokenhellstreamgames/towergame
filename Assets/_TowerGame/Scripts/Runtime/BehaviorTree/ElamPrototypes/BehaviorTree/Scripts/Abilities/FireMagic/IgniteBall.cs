using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Magical Attack with a high chance to apply ignite effect
/// </summary>
[CreateAssetMenu(fileName = "IgniteBall", menuName = "TowerGame/BehaviorTree/Abilities/IgniteBall", order = 1)]
public class IgniteBall : AbilityData
{
    [SerializeField] private int igniteProbability;

    //public IgniteBall(Entity entity) : base(entity)
    //{
    //    Name = "IgniteBall";
    //    Type = AbilityType.Magic;
    //    NumberOfTargets = 1;
    //    Cost = 2;
    //    Power = 20;
    //    TargetPreference = new Random(entity);
    //}


    public override void Run(List<Entity> targetEntities, Entity originEntity, TargetManager targetManager)
    {
        var OriginEntity = originEntity;
        int EntityAttack = Type == AbilityType.Physic ? OriginEntity.CurrentPhysicalAttack : OriginEntity.CurrentMagicalAttack;
        //targetEntities.ForEach(e => e.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type));
        foreach (var target in targetEntities)
        {
            var igniteEffect = new Ignite(OriginEntity, target);
            targetManager.LookTarget(target);
            Instantiate(vfxPrefab, targetManager.ShootPosition.position, targetManager.ShootPosition.rotation);
            target.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type);
            var randomFloat = UnityEngine.Random.Range(0, 100);
            if (randomFloat <= igniteProbability)
            {
                if (OriginEntity.StatusEffects.ContainsKey(igniteEffect.StatusKey))
                {
                    OriginEntity.StatusEffects[igniteEffect.StatusKey].StackEffect();
                }
                else
                {
                    OriginEntity.StatusEffects.Add(igniteEffect.StatusKey, igniteEffect);
                }
            }
        }
    }
}
