using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class GroupController : MonoBehaviour, IDonjonEvent
{
    protected List<BattleCharacterController> characters = new List<BattleCharacterController>();

    public List<BattleCharacterController> Characters => characters;
    public abstract void MoveToNextEncounter();

    public BattleCharacterController GetRandomCharacter(PreferredTargets target, UnitGroupType unitGroupType)
    {
        if (characters.Count == 1)
        {
            return characters[0];
        }
        else if (characters.Count > 1)
        {
            foreach (var character in characters)
            {
                foreach (var status in character.Data.StatusEffect.ControlStatus)
                {
                    if (status == ControlStatus.TAUNT)
                    {
                        return character;
                    }
                }
            }
            if (target == PreferredTargets.RANDOM)
            {
                return characters[UnityEngine.Random.Range(0, characters.Count)];
            }
            foreach (var character in characters)
            {
                foreach (var tag in character.Data.UnitTypeTags)
                {
                    switch (target)
                    {
                        case PreferredTargets.LEADER:
                            if (tag == UnitTypeTags.LEADER)
                            {
                                return character;
                            }
                            break;
                        case PreferredTargets.MELEESUPPORT:
                            if (tag == UnitTypeTags.MELEESUPPORT)
                            {
                                return character;
                            }
                            break;
                        case PreferredTargets.RANGEDSUPPORT:
                            if (tag == UnitTypeTags.RANGEDSUPPORT)
                            {
                                return character;
                            }
                            break;
                        case PreferredTargets.RANGEDDPS:
                            if (tag == UnitTypeTags.RANGEDDPS)
                            {
                                return character;
                            }
                            break;
                        case PreferredTargets.MELEEDPS:
                            if (tag == UnitTypeTags.MELEEDPS)
                            {
                                return character;
                            }
                            break;
                        case PreferredTargets.RANDOM:
                            throw new Exception(" random should have been processed before");
                        default:
                            throw new Exception(" this target is not implemented" + target);
                    }
                }
            }
            return characters[UnityEngine.Random.Range(0, characters.Count)];
        }
        else
        {
            return null;
        }
    }
}
