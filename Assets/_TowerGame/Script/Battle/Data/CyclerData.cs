using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "CyclerData", menuName = "Infinite/Battle/CyclerData")]

public class CyclerData : ScriptableObject
{
    
    [SerializeField] private List<CyclerConditionData> myConditions = new List<CyclerConditionData>();
    [SerializeField] private List<ModifierData> myModifier;
    [SerializeField] private ActionData baseAction;

    public ActionData outputAction { get; set; }

    public List<CyclerConditionData> MyConditions => myConditions;
    public ActionData BaseAction { get => baseAction; set => baseAction = value; }
    public List<ModifierData> MyModifier { get => myModifier; set => myModifier = value; }
}

