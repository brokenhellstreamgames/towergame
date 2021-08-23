using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrafterData", menuName = "Infinite/Shop/CrafterData")]
public class CrafterData : ScriptableObject
{
    [SerializeField] private Sprite portrait;
    [SerializeField] private float speed = 1;


    public Sprite Portrait => portrait;
    public float Speed => speed;


}
