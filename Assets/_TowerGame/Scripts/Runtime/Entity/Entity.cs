﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected bool _alive;

    #region Base Statistics

    [SerializeField]
    protected int _healthPoint;

    [SerializeField]
    protected int _physicalAttack;

    [SerializeField]
    protected int _magicalAttack;

    [SerializeField]
    protected int _physicalDefense;

    [SerializeField]
    protected int _magicalDefense;

    [SerializeField]
    protected int _speed;

    #endregion

    #region Current Statistics

    public int CurrentHealPoint { get; protected set; }


    public int CurrentPhysicalAttack { get; protected set; }


    public int CurrentMagicalAttack { get; protected set; }


    public int CurrentPhysicalDefense { get; protected set; }


    public int CurrentMagicalDefense { get; protected set; }


    public int CurrentSpeed { get; protected set; }

    #endregion

    public int ProActivePoint;

    public EntityActivePoint ProActivePointBehaviour;

    public BehaviorTree BehaviorTree;
    public Coroutine FightCoroutine;

    private void Awake()
    {
        BehaviorTree = new BehaviorTree(this);
        CurrentHealPoint = _healthPoint;
        CurrentPhysicalAttack = _physicalAttack;
        CurrentMagicalAttack = _magicalAttack;
        CurrentPhysicalDefense = _physicalDefense;
        CurrentMagicalDefense = _magicalDefense;
        CurrentSpeed = _speed;

        _alive = true;
    }

    public bool IsAlive()
    {
        return _alive;
    }

    public void TakeDamage(Entity from, int damage, AbilityType type)
    {
        Debug.Log($"{name} Receive damage from {from}");
        int EntityDefense = type == AbilityType.Physic ? CurrentPhysicalDefense : CurrentMagicalDefense;
        CurrentHealPoint = CurrentHealPoint - damage * (EntityDefense/10) < 0 ? 0 : CurrentHealPoint - damage * (EntityDefense/10);
        if (CurrentHealPoint == 0)
        {
            _alive = false;
            gameObject.SetActive(false);
        }
    }

    public void PerformAttack(Ability ability, Modifier modifier)
    {
        Debug.Log($"{name} perform attack {ability.Name}");
        List<Entity> entities = modifier.GetEntities(ability.NumberOfEntities);
        ability.Run(entities);
    }

    public void StartFight()
    {
        FightCoroutine = StartCoroutine(Loop());
    }

    public void StopFight()
    {
        StopCoroutine(FightCoroutine);
    }

    public IEnumerator Loop()
    {
        while (true)
        {
            if (ProActivePoint < GameManager.Instance.MaxProActivePoints)
            {
                yield return ProActivePointBehaviour.Run();
            }

            while (ProActivePoint > 0)
            {
                BehaviorTreeItem behaviorTreeItem = BehaviorTree.GetTreeItem();
                PerformAttack(behaviorTreeItem.Ability, behaviorTreeItem.Modifier);
                ProActivePoint -= behaviorTreeItem.Ability.Cost;
                ProActivePointBehaviour.SetPointText(ProActivePoint);
                behaviorTreeItem.Disable();
                yield return new WaitForSeconds(10 / (CurrentSpeed * Time.fixedDeltaTime));
            }

            yield return new WaitForEndOfFrame();
        }
    }
}