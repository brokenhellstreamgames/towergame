using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Infinite/Battle/UnitData")]
public class UnitData : ScriptableObject
{
    [SerializeField] private Sprite icon = default;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float maxLife = default;
    [SerializeField] private int defaultStanceID = 0;
    [SerializeField] private int maxAtbSegmentStack = 4;
    [SerializeField] private int preferencialAtbSegmentStack = 4;
    [SerializeField] private List<StanceData> stancesLoadout = new List<StanceData>();
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private UnitGroupType unitGroupType = UnitGroupType.MONSTER;
    [SerializeField] private List<UnitTypeTags> unitTypeTags = new List<UnitTypeTags>();
    [SerializeField] private UnitTag unitTag;
    [SerializeField] private UnitStatusEffect statusEffect;

    public float MaxSpeed => maxSpeed;

    public float CurrentSpeed { get; set; }
    public float MaxLife => maxLife;
    public Sprite Icon => icon;
    public float CurrentLife { get; set; }


    public List<StanceData> StancesLoadout => stancesLoadout;

    public GameObject CharacterPrefab => characterPrefab;

    public int DefaultStanceID { get => defaultStanceID; set => defaultStanceID = value; }
    public int MaxAtbSegmentStack => maxAtbSegmentStack;
    public int PreferencialAtbSegmentStack => preferencialAtbSegmentStack;
    public UnitGroupType UnitGroupType => unitGroupType;

    public List<UnitTypeTags> UnitTypeTags => unitTypeTags;

    public UnitStatusEffect StatusEffect { get => statusEffect; set => statusEffect = value; }
}

#region Enums
public enum UnitGroupType
{
    MONSTER,
    HERO
}

public enum UnitTypeTags
{
    LEADER,
    MELEESUPPORT,
    RANGEDSUPPORT,
    RANGEDDPS,
    MELEEDPS,
    TAUNT
}

public enum UnitTag
{
    JOSHUA,
    KAYLE,
    MAXIMUS,
    MONSTER
}


#endregion
