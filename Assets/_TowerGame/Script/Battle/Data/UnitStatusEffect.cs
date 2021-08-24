using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class UnitStatusEffect
{
    [SerializeField] private List<ControlStatus> controlStatus = new List<ControlStatus>();

    public List<ControlStatus> ControlStatus { get => controlStatus; set => controlStatus = value; }
}

public enum ControlStatus
{
    TAUNT,
    CONFUSED,
    STUN
}