public class PhysicalAttack : Modifier
{
    public PhysicalAttack(Entity entity) : base(entity) { }

    public override void ModifyAbility(Ability ability)
    {
        ability.Type = AbilityType.Physic;
    }
}