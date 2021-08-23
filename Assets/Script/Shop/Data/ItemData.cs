using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Infinite/Shop/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private Texture2D icon;
}