using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(MonsterGroupController))]
[RequireComponent(typeof(HeroGroupController))]
public class BattleSystem : MonoBehaviour
{
    private MonsterGroupController enemyGroupController;
    private HeroGroupController heroGroupController;
    private List<BattleCharacterController> actionStack = new List<BattleCharacterController>();
    private BattleUI battleUI;
    private DonjonCameraController donjonCamera;
    private int currentEncounterID = 0;
    public int CurrentEncounterID => currentEncounterID;
    public DonjonEncounter CurrentEncounter { get; private set; }
    public DonjonController DonjonController { get; private set; }
    public BattleCharacterController HoldForNextEncounter { get; set; }

    public HeroGroupController HeroGroupControllerRef => heroGroupController;
    public MonsterGroupController MonsterGroupControllerRef => enemyGroupController;


    private void Awake()
    {
        enemyGroupController = GetComponent<MonsterGroupController>();
        heroGroupController = GetComponent<HeroGroupController>();

        if (Application.isEditor)
        {
            Scene scene;

            scene = SceneManager.GetSceneByName("BattleUIScene");
            if (scene.isSubScene)
                SceneManager.LoadScene("BattleUIScene", LoadSceneMode.Additive);

            scene = SceneManager.GetSceneByName("DonjonScene");
            if (scene.isSubScene)
                SceneManager.LoadScene("DonjonScene", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("BattleUIScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("DonjonScene", LoadSceneMode.Additive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI").GetComponent<BattleUI>();
        DonjonController = GameObject.FindGameObjectWithTag("DonjonController").GetComponent<DonjonController>();
        donjonCamera = Camera.main.GetComponent<DonjonCameraController>();
        CurrentEncounter = DonjonController.DonjonEncounters[currentEncounterID];
    }

    internal void GameOver()
    {
        Debug.Log("Game Over");
    }

    internal void OnEnemyGroupDeath()
    {
        StartCoroutine(EnemyGroupIsDead());
    }

    private IEnumerator EnemyGroupIsDead()
    {
        yield return new WaitForSeconds(3f);
        if(currentEncounterID + 1 < DonjonController.DonjonEncounters.Length)
        {
            CurrentEncounter = DonjonController.DonjonEncounters[currentEncounterID + 1];

            donjonCamera.MoveToNextEncounter();
            heroGroupController.MoveToNextEncounter();
            enemyGroupController.MoveToNextEncounter();

            currentEncounterID++;
        } else
        {
            // DonjonCompleted
            Debug.Log("Donjon Completted");
        }
    }

    internal void EncounterReached()
    {
        //enemyGroupController.InitializeEnemy();
        //HoldForNextEncounter.PerformSkill(this); //todo
    }

    public void BattleFlee ()
    {
        // leave the battle and move to lobby menu
        Debug.Log("Leave battle");
    }

    //public void ProcessStack(BattleCharacterController character, bool add)
    //{
    //    if (add)
    //    {
    //        actionStack.Add(character);
    //        battleUI.AddToQueue(character);
    //        if (actionStack.Count == 1)
    //        {
    //            actionStack[0].PerformSkill(this);
    //        }
    //    }
    //    else
    //    {
    //        if (actionStack.Contains(character))
    //        {
    //            if (actionStack.Count > 1 && actionStack.IndexOf(character) == 0)
    //            {
    //                actionStack[1].PerformSkill(this);
    //            }

    //            actionStack.RemoveAt(actionStack.IndexOf(character));
    //            battleUI.RemoveFromQueue(character.CharacterID);
    //        }

    //    }
    //}


    /// <summary>
    /// Can return null if no target is available
    /// </summary>
    /// <returns></returns>
}
