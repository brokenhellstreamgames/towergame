using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonjonEncounter : MonoBehaviour
{
	[SerializeField] private UnitData boss = default;
	[SerializeField] private Transform bossPosition = default;

	[SerializeField] private UnitData[] enemiesData = default;
	[SerializeField] private Transform playerPosition = default;
	[SerializeField] private Transform enemiesPosition = default;

	public UnitData[] EnemiesData => enemiesData;
	public Transform PlayerPosition => playerPosition;
	public Transform EnemiesPosition => enemiesPosition;
	public UnitData Boss => boss;
	public Transform BossPosition => bossPosition;
}
