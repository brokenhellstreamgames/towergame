public abstract class Modifier
{
    public Entity Entity;
    
    public Modifier(Entity entity)
    {
        Entity = entity;
    }
    
    public abstract void ModifyAbility(Ability ability);
}