using System.Collections.Generic;

public class Random : Modifier
{
    public Random(Entity entity) : base(entity) { }

    public override List<Entity> GetEntities(int numberOfEntities)
    {
        if (Entity is Character)
        {
            return GameManager.Instance.Enemies.Random(numberOfEntities).ToList<Entity>();
        }
        return GameManager.Instance.Characters.Random(numberOfEntities).ToList<Entity>();
    }
}