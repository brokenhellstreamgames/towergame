using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic physical attack, grant empower on hit.
/// </summary>
[CreateAssetMenu(fileName = "ValiantStrike", menuName = "TowerGame/BehaviorTree/Abilities/ValiantStrike", order = 1)]
public class ValiantStrike : AbilityData
{
    [SerializeField] private Empower empowerEffect;
    [SerializeField] int empowerAmount;
    //public ValiantStrike(Entity entity) : base(entity)
    //{
    //    Name = "ValiantStrike";
    //    Type = AbilityType.Physic;
    //    NumberOfTargets = 1;
    //    Cost = 1;
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
