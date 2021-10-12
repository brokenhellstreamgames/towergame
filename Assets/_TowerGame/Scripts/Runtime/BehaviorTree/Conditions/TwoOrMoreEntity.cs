using System.Linq;

public class TwoOrMoreEntity : Condition
{
    public TwoOrMoreEntity(Entity entity) : base(entity) { }
    
    public override bool Check()
    {
        if (Entity is Character)
        {
            return GameManager.Instance.Enemies.Count(e => e.IsAlive()) > 1;
        }

        return GameManager.Instance.Characters.Count(e => e.IsAlive()) > 1;
    }
}