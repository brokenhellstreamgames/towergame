using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private GameObject characterUIPrefabs = default;
    [SerializeField] private GameObject selectedCharacterBannerPrefabs = default;
    [SerializeField] private GameObject queueListPlayerIconPrefabs = default;
    [SerializeField] private GameObject queueListEnemyIconPrefabs = default;
    [SerializeField] private GameObject flyingUITooltip = default;
    [SerializeField] private GameObject queueListUI = default;
    
    private HeroGroupController heroGroupController;
    private int uiOffsetX = 15;
    private List<GameObject> characterInstanceUI = new List<GameObject>();
    private Slider[] sliderATB;
    //private List<CharacterATBProcessor> processedATB = new List<CharacterATBProcessor>();
    private Slider[] sliderLife;
    private Slider[] sliderMana;
    private float[] characterSpeed;
    private GameObject bannerInstance;
    private Transform currentCharacter;
    private List<QueueListIconController> actionQueue = new List<QueueListIconController>();
    private GameObject sceneCanvas;

    //Start is called before the first frame update
    void Start()
    {
        heroGroupController = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<HeroGroupController>();
        sceneCanvas = GameObject.FindGameObjectWithTag("SceneCanvas");

        int characterCount = heroGroupController.Characters.Count;
        sliderATB = sliderLife = sliderMana = new Slider[characterCount];
        characterSpeed = new float[characterCount];
        bannerInstance = Instantiate(selectedCharacterBannerPrefabs, this.transform);

        for (int i = 0; i < characterCount; i++)
        {
            GameObject instance = Instantiate(characterUIPrefabs);
            instance.transform.SetParent(this.transform);
            float height = instance.GetComponent<RectTransform>().sizeDelta.y;
            instance.transform.position = new Vector3(uiOffsetX * (characterCount - i) + 5, height * i);
            characterSpeed[i] = heroGroupController.Characters[i].Data.MaxSpeed;
            foreach (Transform item in instance.transform)
            {
                Slider slider;
                switch (item.name)
                {
                    case "Name":
                        item.GetChild(0).GetComponent<Text>().text = heroGroupController.Characters[i].Data.name;
                        break;
                    case "ATB":
                        slider = item.GetComponent<Slider>();
                        slider.value = 0;
                        sliderATB[i] = slider;
                        break;
                    case "Life":
                        sliderLife[i] = item.GetComponent<Slider>();
                        break;
                }
            }
            characterInstanceUI.Add(instance);
        }
        SetSelectedCharacter(heroGroupController.SelectedCharacter);

        //battleSkillUI.transform.GetChild(2).GetChild(0).GetComponent<Button>().Select();
    }

    internal void ShowDamageTooltips(BattleCharacterController character, int damage)
    {
        var pos = new Vector3(0.2f, 1f, -1f);
        var instance 
            = Instantiate(flyingUITooltip, character.transform.position + pos,
            sceneCanvas.transform.rotation, sceneCanvas.transform).GetComponent<StatusText>();
        instance.ShowText(damage);
    }

    internal void SetSelectedCharacter(int selectedCharacter)
    {
        if(currentCharacter != null)
        {
            currentCharacter.GetChild(0).GetComponent<Outline>().enabled = false;
        }
        currentCharacter = characterInstanceUI[selectedCharacter].transform;
        bannerInstance.transform.position = currentCharacter.position;
        currentCharacter.GetChild(0).GetComponent<Outline>().enabled = true;

        //stanceListController.SwitchCharacter();
    }

    public void UpdateCharacterATB(int characterID, float value)
    {
        sliderATB[characterID].value = value;
    }
    
    //internal void AddToQueue(BattleCharacterController character)
    //{
    //    GameObject instance;
    //    if (character.Data is CharacterData)
    //    {
    //        instance = Instantiate(queueListPlayerIconPrefabs);
    //    } else
    //    {
    //        instance = Instantiate(queueListEnemyIconPrefabs);
    //    }
    //    instance.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = character.Data.Icon;
    //    var btnData = instance.GetComponent<QueueListIconController>();
    //    btnData.CharacterID = character.CharacterID;
    //    actionQueue.Add(btnData);
    //    if (actionQueue.Count < 6)
    //    {
    //        instance.transform.parent = queueListUI.transform;
    //    }
    //}

    //internal void RemoveFromQueue(int characterID)
    //{
    //    for (int i = 0; i < actionQueue.Count; i++)
    //    {
    //        if (characterID == actionQueue[i].CharacterID)
    //        {
    //            Destroy(actionQueue[i].gameObject);
    //            actionQueue.RemoveAt(i);
    //            break;
    //        }
    //    }
    //    if (actionQueue.Count >= 6)
    //    {
    //        actionQueue[6].transform.parent = queueListUI.transform;
    //    }
    //}
}
