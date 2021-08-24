using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

[RequireComponent(typeof(BattleSystem))]
public class HeroGroupController : GroupController/*,ICharacterActionListener,*/ /*, IGroupController*/
{
    [SerializeField] private int playerCharacterCount = 3;
    [SerializeField] private UnitData[] heroUnitsDatas = default;
    [SerializeField] private GameObject cursorPrefabs = default;
    [SerializeField] private Transform instanceHolder = default;
    [SerializeField] private int selectedCharacter = 0;


    
    private BattleUI battleUI;
    private BattleSystem battleSystem;
    //private EnemyGroupController enemyGroupController;
    private bool[] characterCanAct;
    private List<HeroController> charactersInstance = new List<HeroController>();
    private List<HeroController> characterReachedNextEncounter = new List<HeroController>();
    private List<HeroController> deadCharacters = new List<HeroController>();
    private List<StanceProcessor> processors = new List<StanceProcessor>();
    private bool processATB = true;
    private GameObject cursor3DInstance;

    public int SelectedCharacter => selectedCharacter;

    private void Awake()
    {
        battleSystem = GetComponent<BattleSystem>();
    }
        
    private void Start()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI").GetComponent<BattleUI>();
        var currentPlayerPosition = battleSystem.CurrentEncounter.PlayerPosition;
        var playerDefaultLookAt = battleSystem.DonjonController.PlayerDefaultLookAt;

        characterCanAct = new bool[playerCharacterCount];

        for (int i = 0; i < playerCharacterCount; i++)
        {
            var instance = Instantiate(heroUnitsDatas[i].CharacterPrefab, currentPlayerPosition.GetChild(i).position,
                Quaternion.identity, instanceHolder);
            var heroInstance = instance.gameObject.AddComponent<HeroController>();
            heroInstance.Data = heroUnitsDatas[i];
            heroInstance.Data.CurrentSpeed = heroInstance.Data.MaxSpeed;
            heroInstance.Data.CurrentLife = heroInstance.Data.MaxLife;
            heroInstance.BattleSystemRef = battleSystem;
            StanceProcessor stanceProcessor = new StanceProcessor(heroInstance.Data, i);
            processors.Add(stanceProcessor);
            stanceProcessor.heroGroupController = this;
            stanceProcessor.monsterGroupController = battleSystem.MonsterGroupControllerRef;
            ModifierUpdater modifierProcessor = new ModifierUpdater();
            modifierProcessor.ProcessStances(heroInstance.Data);
            stanceProcessor.InitializeStance();
            Characters.Add(heroInstance);
            //instance.AddListener(this);
            heroInstance.CharacterID = i;
            //instance.battleUI = battleUI;
            heroInstance.SetDefaultLookAt(playerDefaultLookAt);
            characterCanAct[i] = false;
            //processedATB.Add(new ATBProcessor(i, heroInstance.Data.Speed));
        }
        //initialise cursor
        cursor3DInstance = Instantiate(cursorPrefabs, Characters[selectedCharacter].transform.position, Quaternion.identity, this.transform);
    }

    public void OnCharacterSelect(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() != 0)
        {
            if (context.ReadValue<float>() > 0)
            {
                selectedCharacter = selectedCharacter + 1 > Characters.Count - 1 ? 0 : selectedCharacter + 1;

            }
            else if (context.ReadValue<float>() < 0)
            {
                selectedCharacter = selectedCharacter - 1 < 0 ? Characters.Count - 1 : selectedCharacter - 1;
            }
            cursor3DInstance.transform.position = Characters[selectedCharacter].transform.position;
            battleUI.SetSelectedCharacter(selectedCharacter);
        }
    }

    internal void SetCharacterIsActive(int characterID, bool isActive)
    {
        characterCanAct[characterID] = isActive;
        if (!isActive)
            ProcessCharacter(characterID);
    }

    internal void ProcessCharacter(int characterID)
    {
        battleUI.UpdateCharacterATB(characterID, 0);
    }

    //Update is called once per frame
    void Update()
    {
        foreach (var processor in processors)
        {
            ProcessedActionData cyclerToPerform = processor.Update();
            if (cyclerToPerform != null)
            {
                Characters[processor.CharacterID].PerformSkill(cyclerToPerform);
            }
        }
    }

    //public void PerformSkill(SkillData skill)
    //{
    //    var character = CharactersInstance[selectedCharacter].GetComponent<BattleCharacterController>();
    //    if (characterCanAct[selectedCharacter])
    //    {
    //        if (character.SkillToPerform != null && !character.IsActing)
    //        {
    //            character.SkillToPerform = skill;
    //        }
    //        else if (character.SkillToPerform == null)
    //        {
    //            character.SkillToPerform = skill;
    //            battleSystem.ProcessStack(character, true);
    //        }
    //    }
    //}


    //public void OnCharacterDeath(BattleCharacterController character)
    //{
    //    if (character is HeroController)
    //    {
    //        deadCharacters.Add((HeroController)character);
    //        charactersInstance.Remove((HeroController)character);
    //        battleSystem.ProcessStack(character, false);
    //        if (charactersInstance.Count < 1)
    //        {
    //            battleSystem.GameOver();
    //        }
    //    }
    //}

    //public void OnCharacterPositionReset(BattleCharacterController character)
    //{
    //    if(character is HeroController) 
    //    {
    //        if(processATB)
    //        {
    //            SetCharacterIsActive(character.CharacterID, false);
    //            battleSystem.ProcessStack(character, false);
    //        } else
    //        {
    //            characterReachedNextEncounter.Add((HeroController)character);
    //            if (characterReachedNextEncounter.Count == CharactersInstance.Count)
    //            {
    //                processATB = true;
    //                battleSystem.EncounterReached();
    //                characterReachedNextEncounter.Clear();
    //            }
    //        }
    //    }
    //}

    public void OnCharacterTakeDamage(BattleCharacterController character, int damage)
    {
        if (character is HeroController)
        {
            battleUI.ShowDamageTooltips(character, damage);
        }
    }

    public override void MoveToNextEncounter()
    {
        processATB = false;
        var currentPlayerPosition = battleSystem.CurrentEncounter.PlayerPosition;
        for (int i = 0; i < Characters.Count; i++)
        {
            ((HeroController)Characters[i]).MoveToNextEncounter(currentPlayerPosition.GetChild(i));
        }
    }
}

