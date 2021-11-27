using System.Collections;
using UnityEngine;

/// <summary>
/// Stackable effect, that trigger upon reaching a stack treshold, thus inflicting damage on the afflicted entity.
/// </summary>
public class CursedIgnition : StatusEffect
{
    private float damagePowerFactor;
    private int stackTriggerTreshold;

    public CursedIgnition(Entity originEntity, Entity targetEntity) : base(originEntity, targetEntity)
    {
        statusKey = "Ignite";
        //baseDuration = 1;
        //Duration = baseDuration;
        stackTriggerTreshold = 4;
        damagePowerFactor = 0.5f;
    }

    public CursedIgnition(Entity originEntity, Entity targetEntity, float newPowerFactor, int stackTreshold) : base(originEntity, targetEntity)
    {
        statusKey = "Ignite";
        //baseDuration = 1;
        //Duration = baseDuration;
        stackTriggerTreshold = stackTreshold;
        damagePowerFactor = newPowerFactor;
    }

    public override int CheckForStacks()
    {
        return CurrentStack;
    }

    public override void Remove()
    {
        Duration = 0;
    }

    public override void Run()
    {
        
    }

    public override void StackEffect(int count)
    {
        CurrentStack += count;
    }

    public override void StackEffect()
    {
        CurrentStack++;
    }

    public override void UnStackEffect(int count)
    {
        CurrentStack -= count;
    }
}
