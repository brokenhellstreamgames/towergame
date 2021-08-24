using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BattleSystem))]
public class MonsterGroupController : GroupController/*,ICharacterActionListener,*/ /*, IGroupController*/
{
    [SerializeField] private Transform instanceHolder = default;

    private List<ATBProcessor> processedATB = new List<ATBProcessor>();
    private List<MonsterController> deadBody = new List<MonsterController>();
    private BattleSystem battleSystem;
    private Transform currentEnemyPosition;
    private BattleUI battleUI;
    private Transform enemyDefaultLookAt;

    private void Awake()
    {
        battleSystem = GetComponent<BattleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI").GetComponent<BattleUI>();
        enemyDefaultLookAt = battleSystem.DonjonController.EnemiesDefaultLookAt;

        InstantiateEnemies();
    }

    private void InstantiateEnemies()
    {
        currentEnemyPosition = battleSystem.CurrentEncounter.EnemiesPosition;
        UnitData[] enemiesData = battleSystem.CurrentEncounter.GetComponent<DonjonEncounter>().EnemiesData;

        for (int i = 0; i < currentEnemyPosition.childCount; i++)
        {
            SetEnemyInstance(enemiesData[(int)UnityEngine.Random.Range(0, enemiesData.Length)],
                currentEnemyPosition.GetChild(i).position, i);
        }

        if(battleSystem.CurrentEncounter.Boss != null)
        {
            SetEnemyInstance(battleSystem.CurrentEncounter.Boss,
                battleSystem.CurrentEncounter.BossPosition.position, currentEnemyPosition.childCount);
        }
    }

    private void SetEnemyInstance(UnitData enemy, Vector3 position, int id)
    {
        var instance = Instantiate(enemy.CharacterPrefab, position, Quaternion.identity, instanceHolder);
        var monsterController = instance.AddComponent<MonsterController>();
        monsterController.Data = enemy;
        monsterController.SetDefaultLookAt(enemyDefaultLookAt);
        monsterController.CharacterID = id;
        //instance.AddListener(this);
        characters.Add(monsterController);
        processedATB.Add(new ATBProcessor(monsterController.CharacterID, monsterController.Data.MaxSpeed));
    }

    // Update is called once per frame
    //void Update()
    //{
    //    for (int i = 0; i < processedATB.Count; i++)
    //    {
    //        var id = processedATB[i].Update(Time.deltaTime);
    //        if (id > -1)
    //        {
    //            processedATB.Remove(processedATB[i]);
    //            i--;
    //            SetEnemyAction(id);
    //        }
    //    }
    //}

    //private void SetEnemyAction(int ID)
    //{
    //    MonsterController enemy = null;
    //    foreach (var enmy in enemies)
    //    {
    //        if (enmy.CharacterID == ID)
    //        {
    //            enemy = enmy;
    //            break;
    //        }
    //    }
    //    if (enemy != null)
    //    {
    //        enemy.SkillToPerform = enemy.Data.ActionSkill[UnityEngine.Random.Range(0, enemy.Data.ActionSkill.Length)];
    //        battleSystem.ProcessStack(enemy, true);
    //    }
    //}

    //public void OnCharacterPositionReset(BattleCharacterController character)
    //{
    //    if(character is MonsterController)
    //    {
    //        processedATB.Add(new ATBProcessor(character.CharacterID, character.Data.Speed));
    //        battleSystem.ProcessStack(character, false);
    //    }
    //}

    public void OnCharacterTakeDamage(BattleCharacterController character, int damage)
    {
        if (character is HeroController)
        {
            battleUI.ShowDamageTooltips(character, damage);
        }
    }

    //public void OnCharacterDeath(BattleCharacterController character)
    //{
    //    if(character is MonsterController)
    //    {
    //        // remove from ATB
    //        for (int i = 0; i < processedATB.Count; i++)
    //        {
    //            if (processedATB[i].ID == character.CharacterID)
    //            {
    //                processedATB.Remove(processedATB[i]);
    //                break;
    //            }
    //        }
    //        deadBody.Add((MonsterController)character);
    //        enemies.Remove((MonsterController)character);
    //        battleSystem.ProcessStack(character, false);

    //        if (enemies.Count < 1)
    //        {
    //            battleSystem.OnEnemyGroupDeath();
    //            foreach (var body in deadBody)
    //            {
    //                body.RemoveFromBattle();
    //            }
    //            deadBody.Clear();
    //            enemies.Clear();
    //        }
    //    }
    //}

    /// <summary>
    /// Can return null if no character is aivalable
    /// </summary>
    /// <returns></returns>

    public override void MoveToNextEncounter()
    {
        InstantiateEnemies();
    }
}