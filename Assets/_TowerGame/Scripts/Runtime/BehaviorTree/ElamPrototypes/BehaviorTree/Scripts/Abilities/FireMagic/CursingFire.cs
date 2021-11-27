using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Magical attack, applies a CursedIgnition stack if target is affected by Ignite, then cleanse ignite.
/// </summary>
[CreateAssetMenu(fileName = "CursingFire", menuName = "TowerGame/BehaviorTree/Abilities/CursingFire", order = 1)]
public class CursingFire : AbilityData
{
    //public CursingFire(Entity entity) : base(entity)
    //{
    //    Name = "CursedFire";
    //    Type = AbilityType.Magic;
    //    NumberOfTargets = 1;
    //    Cost = 1;
    //    Power = 20;
    //    TargetPreference = new Random(entity);
    //}


    public override void Run(List<Entity> targetEntities, Entity originEntity, TargetManager targetManager)
    {
        var OriginEntity = originEntity;
        int EntityAttack = Type == AbilityType.Physic ? OriginEntity.CurrentPhysicalAttack : OriginEntity.CurrentMagicalAttack;
        foreach (var target in targetEntities)
        {
            var igniteEffect = new Ignite(OriginEntity, target);
            if (target.StatusEffects.ContainsKey(igniteEffect.StatusKey))
            {
                target.StatusEffects[igniteEffect.StatusKey].Remove();
                var cursedIgnitionEffect = new CursedIgnition(OriginEntity, target);
                target.StatusEffects.Add(cursedIgnitionEffect.StatusKey, cursedIgnitionEffect);
            }
            targetManager.LookTarget(target);
            Instantiate(vfxPrefab, targetManager.ShootPosition.position, targetManager.ShootPosition.rotation);
            target.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type);
        }
    }
}

