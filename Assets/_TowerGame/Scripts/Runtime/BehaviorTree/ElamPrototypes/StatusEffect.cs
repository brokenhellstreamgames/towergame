using System.Collections;
using UnityEngine;

public abstract class StatusEffect
{
    protected string statusKey;
    public Entity AffectedEntity;
    public Entity OriginEntity;
    public int CurrentStack;
    public int Duration;
    public int baseDuration;

    public StatusEffect(Entity originEntity, Entity targetEntity)
    {
        OriginEntity = originEntity;
        AffectedEntity = targetEntity;
    }

    public StatusEffect() { }

    public string StatusKey => statusKey;
    public abstract void Run();
    public abstract void StackEffect(int count);
    public abstract void StackEffect();
    public abstract void UnStackEffect(int count);
    public abstract int CheckForStacks();
    public abstract void Remove();
}
