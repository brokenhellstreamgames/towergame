using System.Collections;
using UnityEngine;

    public class ModifierUpdater
    {
        public void ProcessStances(UnitData unit)
        {
            foreach (var stance in unit.StancesLoadout)
            {
                foreach (var cyclerData in stance.CyclersList)
                {
                    ProcessAbility(cyclerData);
                }
            }

        }
        private void ProcessAbility (CyclerData cyclerData)
        {
            cyclerData.outputAction = cyclerData.BaseAction.DeepCopy();
            foreach (var modifier in cyclerData.MyModifier)
            {
                switch (modifier.ModifierTag)
                {
                    case ModifierTAGS.SLASH:
                        SlashModifier(cyclerData.outputAction);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void SlashModifier (ActionData action)
        {
            action.DamageType.Add(DamageTypes.SLASH);
        }

    }
