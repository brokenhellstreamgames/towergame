using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : BattleCharacterController
{
    protected override TargetGroup GetTargetType()
    {
        return TargetGroup.MONSTER;
    }

    internal void MoveToNextEncounter(Transform newPosition)
    {
        startPosition = newPosition.position;
        targetTransform = newPosition;
        resetPosition = true;
        StartMovement(true);
    }
}
