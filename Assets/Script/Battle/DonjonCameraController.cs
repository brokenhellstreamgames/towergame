using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DonjonCameraController : MonoBehaviour, IDonjonEvent
{
    private Animator animator;
    private BattleSystem battleSystem;
    private float defaultSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        battleSystem = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>();
    }

    public void OnWaypointReached()
    {
        defaultSpeed = animator.speed;
        animator.speed = 0;
    }

    public void MoveToNextEncounter()
    {
        if (battleSystem.CurrentEncounterID == 0)
            animator.enabled = true;
        else
            animator.speed = defaultSpeed;
    }
}
