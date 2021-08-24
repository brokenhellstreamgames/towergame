using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceProcessor
{
    private StanceData stanceData;
    private List<CyclerData> cyclersToProcess;
    private UnitData unitData;
    private int characterID;
    private int processStep;
    private int processMaxStep;
    private int atbSegmentStack;
    float value = 0;

    public HeroGroupController heroGroupController { private get; set; }
    public MonsterGroupController monsterGroupController { private get; set; }

    public int CharacterID => characterID;

    public StanceProcessor(UnitData data, int characterID)
    {
        unitData = data;
        this.characterID = characterID;
        stanceData = unitData.StancesLoadout[unitData.DefaultStanceID];
    }


    public ProcessedActionData Update()
    {
        value += Time.deltaTime * unitData.CurrentSpeed;
        Debug.Log(value);
        if (value >= 1)
        {
            atbSegmentStack += 1;
            value = 0;
            Debug.Log(" i charged one segment " + atbSegmentStack);
        }
        if (atbSegmentStack >= unitData.PreferencialAtbSegmentStack)
        {
            return ProcessThroughCyclers();
        }
        return null;
    }



    // Use this for initialization
    public void InitializeStance()
    {
        processStep = 0;
        cyclersToProcess = new List<CyclerData>(stanceData.CyclersList);
    }

    public ProcessedActionData ProcessThroughCyclers()
    {
        if (processStep >= processMaxStep)
        {
            InitializeStance();
            
        }
        processStep++;
        List<CyclerData> processableCyclers = cyclersToProcess;
        foreach (CyclerData cyclerData in processableCyclers)
        {
            var processedActionData = Process(cyclerData);
            if (processedActionData != null)
            {
                cyclersToProcess.Remove(cyclerData);

                return processedActionData;
            }
        }
        return null;
    }

    private ProcessedActionData Process(CyclerData cycler)
    {
        foreach (var condition in cycler.MyConditions)
        {
            switch (condition.ConditionType)
            {
                case CyclerCondition.ORDER:
                    if (ProcessCondition(condition.OrderCondition))
                    {
                        break;
                    }
                    return null;
                case CyclerCondition.STATUS:
                    if (ProcessCondition(condition.StatusCondition))
                    {
                        break;
                    }
                    return null;
                case CyclerCondition.RESSOURCES:
                    if (ProcessCondition(condition.RessourcesCondition))
                    {
                        break;
                    }
                    return null;
                default:
                    throw new System.Exception("This condition does not exist : " + condition.ConditionType);
            }
        }
        return new ProcessedActionData(cycler.outputAction, 
            ProcessTarget(cycler.outputAction.PreferredTargetGroup, cycler.outputAction.PreferredTarget));
    }

    private BattleCharacterController ProcessTarget(PreferredTargetGroup targetGroup, PreferredTargets target)
    {
        switch (targetGroup)
        {
            case PreferredTargetGroup.ALLY:
                switch (unitData.UnitGroupType)
                {
                    case UnitGroupType.MONSTER:
                        return monsterGroupController.GetRandomCharacter(target, unitData.UnitGroupType);
                    case UnitGroupType.HERO:
                        return heroGroupController.GetRandomCharacter(target, unitData.UnitGroupType);
                    default:
                        throw new System.Exception("This UnitGroupeType isn't implemented" + unitData.UnitGroupType);
                }
            case PreferredTargetGroup.ENEMY:
                switch (unitData.UnitGroupType)
                {
                    case UnitGroupType.MONSTER:
                        return heroGroupController.GetRandomCharacter(target, unitData.UnitGroupType);
                    case UnitGroupType.HERO:
                        return monsterGroupController.GetRandomCharacter(target, unitData.UnitGroupType);
                    default:
                        throw new System.Exception("This UnitGroupeType isn't implemented" + unitData.UnitGroupType);
                }
            case PreferredTargetGroup.SELF:
                return null;
            default:
                throw new System.Exception("This preferred group type isn't implemented " + unitData.UnitGroupType);
        }
    }

    #region Cyclers Conditions Process
    private bool ProcessCondition(ORDER orderCondition)
    {
        switch (orderCondition)
        {
            case ORDER.FIRST:
                return true;
            case ORDER.NEXT:
                return true;
            case ORDER.LAST:
                return true;
            default:
                throw new System.Exception("This order condition does not exist : " + orderCondition);
        }
        throw new NotImplementedException();
    }

    private bool ProcessCondition(ControlStatus statusCondition)
    {
        switch (statusCondition)
        {
            case ControlStatus.TAUNT:
                break;
            case ControlStatus.STUN:
                break;
            case ControlStatus.CONFUSED:
                break;
            default:
                throw new System.Exception("This status condition does not exist : " + statusCondition);
        }
        throw new NotImplementedException();
    }

    private bool ProcessCondition(RESSOURCES ressourcesCondition)
    {
        switch (ressourcesCondition)
        {
            case RESSOURCES.HP:
                break;
            case RESSOURCES.TIME:
                break;
            default:
                throw new System.Exception("This ressources condition does not exist : " + ressourcesCondition);
        }
        throw new NotImplementedException();
    }
    #endregion
}

