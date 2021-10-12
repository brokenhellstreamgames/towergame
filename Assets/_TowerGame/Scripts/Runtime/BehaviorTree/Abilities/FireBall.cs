using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ability
{
    public FireBall(Entity entity) : base(entity)
    {
        Name = "Fire Ball";
        Type = AbilityType.Magic;
        Cost = 2;
        Power = 150;
        NumberOfEntities = 1;
    }

    public override void Run(List<Entity> entity)
    {
        int EntityAttack = Type == AbilityType.Physic ? Entity.CurrentPhysicalAttack : Entity.CurrentMagicalAttack;
        entity.ForEach(e => e.TakeDamage(Entity, EntityAttack * Power / 100, Type));
    }
}