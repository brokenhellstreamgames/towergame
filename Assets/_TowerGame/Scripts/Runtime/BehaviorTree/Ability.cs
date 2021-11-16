using System.Collections.Generic;

public enum AbilityType
{
    Physic,
    Magic
}

public abstract class Ability
{
    public Entity Entity;

    public string Name;
    public int NumberOfEntities;
    public int Cost;
    public AbilityType Type;
    public int Power;
    public TargetPreference TargetPreference;

    public Ability(Entity entity)
    {
        Entity = entity;
    }
    
    public abstract void Run(List<Entity> entity);

    public bool CanBeUsed()
    {
        return Cost <= Entity.ProActivePoint;
    }
}
