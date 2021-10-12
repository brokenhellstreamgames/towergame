using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : Ability
{
    public BaseAttack(Entity entity) : base(entity)
    {
        Name = "Base Attack";
        Type = AbilityType.Physic;
        Cost = 1;
        Power = 50;
        NumberOfEntities = 1;
    }
    
    public override void Run(List<Entity> entity)
    {
        int EntityAttack = Type == AbilityType.Physic ? Entity.CurrentPhysicalAttack : Entity.CurrentMagicalAttack;
        entity.ForEach(e => e.TakeDamage(Entity, EntityAttack * Power / 100, Type));
    }
}