using System.Collections;
using UnityEngine;

/// <summary>
/// Stackable effect that increase entity damage for each additionnal stack
/// </summary>
public class Empower : StatusEffect
{
    public float EmpowerPowerFactor;

    public Empower(Entity originEntity, Entity targetEntity) : base(originEntity, targetEntity)
    {
        statusKey = "Empower";
        baseDuration = 6;
        Duration = baseDuration;
        EmpowerPowerFactor = 20;
        Run();
    }

    public Empower() { }

    public override void Remove()
    {
    }

    public override void Run()
    {
    }

    public override void StackEffect(int count)
    {
        CurrentStack += 1;
    }

    public override void StackEffect()
    {
        Duration = baseDuration;
    }

    public override void UnStackEffect(int count)
    {
        CurrentStack -= 1;
    }

    public override int CheckForStacks()
    {
        return CurrentStack;
    }

    public IEnumerator CountdownToRemove()
    {
        while (Duration > 0)
        {
            yield return new WaitForSeconds(1f);
            Duration--;
        }
    }
}
