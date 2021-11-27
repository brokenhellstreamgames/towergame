using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// Status effect, non stackable, deal damage over time
/// </summary>
public class Ignite : StatusEffect
{
    public float IgnitePowerFactor;

    public Ignite(Entity originEntity, Entity targetEntity) : base(originEntity, targetEntity)
    {
        statusKey = "Ignite";
        baseDuration = 2;
        Duration = baseDuration;
        IgnitePowerFactor = 0.5f;
        Run();
    }

    public Ignite(Entity originEntity, Entity targetEntity, float newPowerFactor, int duration) : base(originEntity, targetEntity)
    {
        statusKey = "Ignite";
        baseDuration = duration;
        Duration = baseDuration;
        IgnitePowerFactor = newPowerFactor;
        Run();
    }

    public Ignite() { }


    public override int CheckForStacks()
    {
        return 1;
    }

    public override void Remove()
    {
        Duration = 0;
        AffectedEntity.StatusEffects.Remove(statusKey);
    }

    public override void Run()
    {
        DamageOverTime();
    }

    public override void StackEffect(int count)
    {
    }

    public override void StackEffect()
    {
        Duration = baseDuration;
    }

    public override void UnStackEffect(int count)
    {
    }

    private IEnumerator DamageOverTime()
    {
        while (Duration > 0)
        {
            yield return new WaitForSeconds(1f);
            Duration--;
            AffectedEntity.TakeDamage(OriginEntity, OriginEntity.CurrentMagicalAttack * IgnitePowerFactor / 100, AbilityType.Magic);
        }
    }
}
