using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstance
{
    public GameObject vfxPrefab;
    public TargetPreferenceV2 TargetPreference;
    public AbilityData originAbilityData;
    public string Name;
    public int NumberOfTargets;
    public int Cost;
    public AbilityType Type;
    public int Power;

    public AbilityInstance(AbilityData abilityData)
    {
        originAbilityData = abilityData;
        vfxPrefab = originAbilityData.vfxPrefab;
        TargetPreference = originAbilityData.TargetPreference;
        Name = originAbilityData.name;
        NumberOfTargets = originAbilityData.NumberOfTargets;
        Cost = originAbilityData.Cost;
        Type = originAbilityData.Type;
        Power = originAbilityData.Power;
    }
    public void Run(List<Entity> entity, Entity originEntity, TargetManager targetManager)
    {
        originAbilityData.Run(entity, originEntity, targetManager);
        Reset();
    }

    public void Reset()
    {
        vfxPrefab = originAbilityData.vfxPrefab;
        TargetPreference = originAbilityData.TargetPreference;
        Name = originAbilityData.name;
        NumberOfTargets = originAbilityData.NumberOfTargets;
        Cost = originAbilityData.Cost;
        Type = originAbilityData.Type;
        Power = originAbilityData.Power;
    }

    public bool CanBeUsed(Entity originEntity)
    {
        return Cost <= originEntity.ProActivePoint;
    }
}
