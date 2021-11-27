using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Multi hit physical attack, grant empower on hit.
/// </summary>
[CreateAssetMenu(fileName = "ValiantFlurry", menuName = "TowerGame/BehaviorTree/Abilities/ValiantFlurry", order = 1)]
public class ValiantFlurry : AbilityData
{
    [SerializeField] int empowerAmount;
    [SerializeField] int strikeCount;
    //public ValiantFlurry(Entity entity) : base(entity)
    //{
    //    Name = "ValiantFlurry";
    //    Type = AbilityType.Physic;
    //    NumberOfTargets = 1;
    //    Cost = 1;
    //    Power = 10;
    //    TargetPreference = new Random(entity);
    //}


    public override void Run(List<Entity> targetEntities, Entity originEntity, TargetManager targetManager)
    {
        var OriginEntity = originEntity;
        int EntityAttack = Type == AbilityType.Physic ? OriginEntity.CurrentPhysicalAttack : OriginEntity.CurrentMagicalAttack;
        var empowerEffect = new Empower(OriginEntity, OriginEntity);
        for (int i = 0; i < strikeCount; i++)
        {
            //targetEntities.ForEach(e => e.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type));
            foreach (var target in targetEntities)
            {
                targetManager.LookTarget(target);
                Instantiate(vfxPrefab, targetManager.ShootPosition.position, targetManager.ShootPosition.rotation);
                target.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type);
            }
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
