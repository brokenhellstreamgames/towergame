using System;
using System.Collections.Generic;

public abstract class Modifier
{
    public Entity Entity;

    public List<Entity> Targets;

    public Modifier(Entity entity)
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
