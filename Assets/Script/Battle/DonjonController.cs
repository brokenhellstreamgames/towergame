using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonjonController : MonoBehaviour
{
    [SerializeField] private DonjonEncounter[] donjonEncounters = default;
    [SerializeField] private Transform playerDefaultLookAt = default;
    [SerializeField] private Transform enemiesDefaultLookAt = default;

    public DonjonEncounter[] DonjonEncounters => donjonEncounters;
    public Transform PlayerDefaultLookAt => playerDefaultLookAt;
    public Transform EnemiesDefaultLookAt => enemiesDefaultLookAt;
}
