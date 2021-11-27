using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Inflict magical damage & deal bonus damage if target is affected by ignite then cleanse ignite on target
/// </summary>
[CreateAssetMenu(fileName = "Combustion", menuName = "TowerGame/BehaviorTree/Abilities/Combustion", order = 1)]
public class Combustion : AbilityData
{
    [SerializeField] Ignite ingiteEffect;
    [SerializeField] private int powerAdditiveFactor;

    //public Combustion(Entity entity) : base(entity)
    //{
    //    Name = "Combustion";
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
        foreach (var target in targetEntities)
        {
            var igniteEffect = new Ignite(OriginEntity, target);
            if (target.StatusEffects.ContainsKey(igniteEffect.StatusKey))
            {
                target.StatusEffects[ingiteEffect.StatusKey].Remove();
                Power += powerAdditiveFactor;
            }
            target.TakeDamage(OriginEntity, EntityAttack * Power / 100, Type);
        }
    }
}
