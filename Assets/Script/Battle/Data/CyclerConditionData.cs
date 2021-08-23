using System;
using UnityEngine;

[Serializable]
public class CyclerConditionData
{
    [SerializeField] private CyclerCondition conditionType;
    //[SerializeField] private TargetGroup targetcondition;
    [SerializeField] private ORDER orderCondition;
    [SerializeField] private ControlStatus statusCondition;
    [SerializeField] private RESSOURCES ressourcesCondition;

    public CyclerCondition ConditionType { get => conditionType; set => conditionType = value; }
    //public TargetGroup Targetcondition { get => targetcondition; set => targetcondition = value; }
    public ORDER OrderCondition { get => orderCondition; set => orderCondition = value; }
    public ControlStatus StatusCondition { get => statusCondition; set => statusCondition = value; }
    public RESSOURCES RessourcesCondition { get => ressourcesCondition; set => ressourcesCondition = value; }
}

public enum CyclerCondition
{
    RESSOURCES,
    STATUS,
    ORDER
}

public enum ORDER
{
    FIRST,
    NEXT,
    LAST
}

public enum RESSOURCES
{
    HP,
    TIME
}

public class OrderCondition
{
    public ORDER order;
    public TargetGroup targetGroup;
    public OrderCondition(ORDER order, TargetGroup targetGroup)
    {
        this.order = order;
        this.targetGroup = targetGroup;
    }
}

