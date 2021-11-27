using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deal physical damage, Consume empower, deal additionnal damage for each empower stack consumed
/// </summary>
[CreateAssetMenu(fileName = "ProofOfValor", menuName = "TowerGame/BehaviorTree/Abilities/ProofOfValor", order = 1)]
public class ProofOfValor : AbilityData
{
    [SerializeField] private int powerAdditiveFactor;

    //public ProofOfValor(Entity entity) : base(entity)
    //{
    //    Name = "ProofOfValor";
    //    Type = AbilityType.Physic;
    //    NumberOfTargets = 1;
    //    Cost = 3;
    //    Power = 50;
    //    TargetPreference = new Random(entity);
    //}


    public override void Run(List<Entity> targetEntities, Entity originEntity, TargetManager targetManager)
    {
        var OriginEntity = originEntity;
        var empowerInstance = new Empower(OriginEntity, OriginEntity);
        if (OriginEntity.StatusEffects.ContainsKey(empowerInstance.StatusKey))
        {
            Power += (powerAdditiveFactor * OriginEntity.StatusEffects[empowerInstance.StatusKey].CheckForStacks());
        }
        int EntityAttack = Type == AbilityType.Physic ? OriginEntity.CurrentPhysicalAttack : OriginEntity.CurrentMagicalAttack;
        targetEntities.ForEach(e => e.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type));
    }
}
