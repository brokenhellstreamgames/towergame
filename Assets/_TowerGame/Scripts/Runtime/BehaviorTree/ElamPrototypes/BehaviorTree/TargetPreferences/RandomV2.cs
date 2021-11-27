using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomV2", menuName = "TowerGame/BehaviorTree/TargetPreferences/Random", order = 1)]
public class RandomV2 : TargetPreferenceV2
{
    public override void ComputeEntities(int numberOfEntities, Entity originEntity)
    {
        if (originEntity is Character)
        {
            Targets = GameManager.Instance.Enemies.Random(numberOfEntities).ToList<Entity>();
        }
        else
        {
            Targets = GameManager.Instance.Characters.Random(numberOfEntities).ToList<Entity>();
        }
    }
}