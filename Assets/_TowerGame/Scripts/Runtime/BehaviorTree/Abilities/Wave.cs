using System.Collections.Generic;
using UnityEngine;

public class Wave : Ability
{
    public Wave(Entity entity) : base(entity)
    {
        Name = "Wave";
        Type = AbilityType.Magic;
        NumberOfEntities = 3;
        Cost = 3;
        Power = 100;
        TargetPreference = new HPGreatier(entity);
    }

    public override void Run(List<Entity> entity)
    {
        int EntityAttack = Type == AbilityType.Physic ? Entity.CurrentPhysicalAttack : Entity.CurrentMagicalAttack;
        entity.ForEach(e => e.TakeDamage(Entity, EntityAttack * Power / 100, Type));
    }
}