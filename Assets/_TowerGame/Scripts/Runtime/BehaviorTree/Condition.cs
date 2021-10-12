public abstract class Condition
{
    public Entity Entity;
    public bool Available;

    public Condition(Entity entity)
    {
        Entity = entity;
    }
    
    public abstract bool Check();
}
