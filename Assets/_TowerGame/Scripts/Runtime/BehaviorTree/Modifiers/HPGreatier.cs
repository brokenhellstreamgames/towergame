using System.Collections.Generic;
using System.Linq;

public class HPGreatier : Modifier
{
    public HPGreatier(Entity entity) : base(entity) { }

    public override void ComputeEntities(int numberOfEntities)
    {
        if (Entity is Character)
        {
            Targets = GameManager.Instance.Enemies.OrderByDescending(e => e.CurrentHealPoint).Take(numberOfEntities)
                .ToList<Entity>();
        }

        Targets = GameManager.Instance.Characters.OrderByDescending(e => e.CurrentHealPoint).Take(numberOfEntities)
            .ToList<Entity>();
    }
}