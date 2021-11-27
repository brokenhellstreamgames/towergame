using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    [SerializeField] public GameObject vfxPrefab;
    [SerializeField] public TargetPreferenceV2 TargetPreference;

    public string Name;
    public int NumberOfTargets;
    public int Cost;
    public AbilityType Type;
    public int Power;

    public abstract void Run(List<Entity> entity, Entity originEntity, TargetManager targetManager);
}
