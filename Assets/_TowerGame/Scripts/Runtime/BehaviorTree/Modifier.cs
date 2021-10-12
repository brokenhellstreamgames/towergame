using System.Collections.Generic;

public abstract class Modifier
{
    public Entity Entity;

    public Modifier(Entity entity)
    {
        Entity = entity;
    }

    public abstract List<Entity> GetEntities(int numberOfEntities);
}
