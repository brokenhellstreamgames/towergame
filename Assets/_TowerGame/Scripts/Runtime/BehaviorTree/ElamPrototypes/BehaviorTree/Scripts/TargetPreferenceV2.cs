using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetPreferenceV2 : ScriptableObject
{

    public List<Entity> Targets;

    public abstract void ComputeEntities(int numberOfEntities, Entity originEntity);

    public List<Entity> GetEntities()
    {
        if (Targets == null || Targets.Count == 0)
        {
            throw new Exception("No target in this modifier");
        }
        return Targets;
    }
}

