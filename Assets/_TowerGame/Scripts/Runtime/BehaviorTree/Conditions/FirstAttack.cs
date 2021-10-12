public class FirstAttack : Condition
{
    public FirstAttack(Entity entity) : base(entity) { }
    
    public override bool Check()
    {
        return true;
    }

}