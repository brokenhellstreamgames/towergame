using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StanceData", menuName = "Infinite/Battle/StanceData")]
public class StanceData : ScriptableObject
{
    [SerializeField] private Sprite stanceIcon;
    [SerializeField] private string stanceName;
    [SerializeField] private int animID = -1;
    [SerializeField] private List<CyclerData> cyclerList = new List<CyclerData>();
    //[SerializeField] private int myCharacterID;
    
    public List<CyclerData> CyclersList { get => cyclerList; set => cyclerList = value; }

    public Sprite StanceIcon => stanceIcon;
    public string StanceName => stanceName;
    public int AnimID => animID;
    //public int CharacterID => myCharacterID;
}