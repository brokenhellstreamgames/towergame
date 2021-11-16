using System;
using System.Collections.Generic;

public abstract class TargetPreference
{
    public Entity Entity;

    public List<Entity> Targets;

    public TargetPreference(Entity entity)
    {
        Entity = entity;
    }

    public abstract void ComputeEntities(int  numberOfEntities);
    
    public List<Entity> GetEntities()
    {
        if (Targets == null || Targets.Count == 0)
        {
            throw new Exception("No target in this modifier");
        }
        return Targets;
    }
}
