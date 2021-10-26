using System.Collections.Generic;

public class Random : Modifier
{
    public Random(Entity entity) : base(entity) { }

    public override void ComputeEntities(int numberOfEntities)
    {
        if (Entity is Character)
        {
            Targets = GameManager.Instance.Enemies.Random(numberOfEntities).ToList<Entity>();
        }
        Targets = GameManager.Instance.Characters.Random(numberOfEntities).ToList<Entity>();
    }
}