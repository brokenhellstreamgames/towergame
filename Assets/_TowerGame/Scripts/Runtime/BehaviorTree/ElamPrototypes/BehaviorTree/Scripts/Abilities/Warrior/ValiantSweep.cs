using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aoe attack grants empower for each hit.
/// </summary>
[CreateAssetMenu(fileName = "ValiantSweep", menuName = "TowerGame/BehaviorTree/Abilities/ValiantSweep", order = 1)]
public class ValiantSweep : AbilityData
{
    [SerializeField] int empowerAmount;

    //public ValiantSweep(Entity entity) : base(entity)
    //{
    //    Name = "ValiantSweep";
    //    Type = AbilityType.Physic;
    //    NumberOfTargets = 3;
    //    Cost = 2;
    //    Power = 20;
    //    TargetPreference = new Random(entity);
    //}

    public override void Run(List<Entity> targetEntities, Entity originEntity, TargetManager targetManager)
    {
        var OriginEntity = originEntity;
        int EntityAttack = Type == AbilityType.Physic ? OriginEntity.CurrentPhysicalAttack : OriginEntity.CurrentMagicalAttack;
        //targetEntities.ForEach(e => e.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type));
        var empowerEffect = new Empower(OriginEntity, OriginEntity);
        foreach (var target in targetEntities)
        {
            targetManager.LookTarget(target);
            Instantiate(vfxPrefab, targetManager.ShootPosition.position, targetManager.ShootPosition.rotation);
            target.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type);
            if (OriginEntity.StatusEffects.ContainsKey(empowerEffect.StatusKey))
            {
                OriginEntity.StatusEffects[empowerEffect.StatusKey].StackEffect(empowerAmount);
            }
            else
            {
                OriginEntity.StatusEffects.Add(empowerEffect.StatusKey, empowerEffect);
            }
        }
    }
}
