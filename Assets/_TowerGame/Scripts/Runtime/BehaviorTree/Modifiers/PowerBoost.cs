public class PowerBoost : Modifier
{
    public PowerBoost(Entity entity) : base(entity) { }

    public override void ModifyAbility(Ability ability)
    {
        ability.Power = (int) (ability.Power * 1.2f);
    }
}