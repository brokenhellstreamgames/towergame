using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ModifierData", menuName = "Infinite/Battle/ModifierData")]

public class ModifierData : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private string description;
    [SerializeField] private ModifierTAGS modifierTag;

    public Sprite Image => image;

    public string Description => description;

    public ModifierTAGS ModifierTag { get => modifierTag; set => modifierTag = value;}

}

public enum ModifierTAGS
{
    SLASH,
    BLUNT
}