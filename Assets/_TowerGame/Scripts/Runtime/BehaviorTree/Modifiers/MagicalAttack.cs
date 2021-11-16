public class MagicalAttack : Modifier
{
    public MagicalAttack(Entity entity) : base(entity) { }
    
    public override void ModifyAbility(Ability ability)
    {
        ability.Type = AbilityType.Magic;
    }
}