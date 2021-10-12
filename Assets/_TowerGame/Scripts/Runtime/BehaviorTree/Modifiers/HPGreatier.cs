using System.Collections.Generic;
using System.Linq;

public class HPGreatier : Modifier
{
    public HPGreatier(Entity entity) : base(entity) { }

    public override List<Entity> GetEntities(int numberOfEntities)
    {
        if (Entity is Character)
        {
            return GameManager.Instance.Enemies.OrderByDescending(e => e.CurrentHealPoint).Take(numberOfEntities)
                .ToList<Entity>();
        }

        return GameManager.Instance.Characters.OrderByDescending(e => e.CurrentHealPoint).Take(numberOfEntities)
            .ToList<Entity>();
    }
}