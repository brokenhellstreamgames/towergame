using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionData", menuName = "Infinite/Battle/ActionData")]
public class ActionData : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private string description;
    [SerializeField] private float damage;
    [SerializeField] private int animID;
    [SerializeField] private ActionTypeTag myTypeTag;
    [SerializeField] private List<DamageTypes> damageType = new List<DamageTypes>();
    [SerializeField] private PreferredTargets preferredTarget = PreferredTargets.RANDOM;
    [SerializeField] private PreferredTargetGroup preferredTargetGroup = PreferredTargetGroup.ENEMY;
    [SerializeField] private List<DebuffEffects> debuffEffect = new List<DebuffEffects>();
    [SerializeField] private List<BuffEffects> buffEffect = new List<BuffEffects>();

    public ActionTypeTag MyActionTypeTag => MyTypeTag;

    public Sprite Image => image;
    public string Description => description;
    public int AnimID => animID;



    public ActionTypeTag MyTypeTag { get => myTypeTag; set => myTypeTag = value; }
    public List<DamageTypes> DamageType { get => damageType; set => damageType = value; }
    public PreferredTargets PreferredTarget { get => preferredTarget; set => preferredTarget = value; }
    public List<DebuffEffects> DebuffEffect { get => debuffEffect; set => debuffEffect = value; }
    public List<BuffEffects> BuffEffect { get => buffEffect; set => buffEffect = value; }
    public float Damage { get => damage; set => damage = value; }
    public PreferredTargetGroup PreferredTargetGroup { get => preferredTargetGroup; set => preferredTargetGroup = value; }

    public ActionData DeepCopy()
    {
        var copy = CreateInstance<ActionData>();
        copy.description = description;
        copy.damage = damage;
        copy.myTypeTag = myTypeTag;
        copy.damageType = damageType;
        copy.preferredTarget = preferredTarget;
        copy.debuffEffect = debuffEffect;
        copy.buffEffect = BuffEffect;
        copy.animID = animID;

        return copy;
    }
}

#region Enums
public enum ActionTypeTag
{
    RANGED,
    MELEE
}

public enum PreferredTargets
{
    LEADER,
    MELEESUPPORT,
    RANGEDSUPPORT,
    RANGEDDPS,
    MELEEDPS,
    RANDOM
}

public enum PreferredTargetGroup
{
    ENEMY,
    ALLY,
    SELF
}

public enum BuffEffects
{
    FORTIFY,
    HASTE,
    BLOCKADE
}

public enum DebuffEffects
{
    SLOW,
    BLEED,
    BURNING,
    FREEZE,
    ELECTROCUTE,
    BRITTLE
}

public enum DamageTypes
{
    NONE,
    BLUNT,
    SLASH,
    PIERCE,
    FIRE,
    COLD,
    ELECTRIC,
    LIGHT
}
#endregion
