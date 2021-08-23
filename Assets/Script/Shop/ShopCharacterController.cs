using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCharacterController : MonoBehaviour
{
    [SerializeField] private CrafterData data = default;

    public CrafterData Data => data;
}
