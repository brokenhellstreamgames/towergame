using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class StanceListController : MonoBehaviour
{
    [SerializeField] private List<StanceButton> stanceButtons;
    [SerializeField] private Transform tabViewport;
    [SerializeField] private Button actionBtn;

    private HeroGroupController heroGroupController;
    //private GameObject[][] tabsInstance;
    //private GameObject itemsTabs; // pour les items
    private int selectedCharacter = 0;
    private Outline activeBtnOutline;

    // Start is called before the first frame update
    void Start()
    {
        heroGroupController = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<HeroGroupController>();

        //tabsInstance = new GameObject[heroGroupController.CharactersInstance.Count][];
        ////Charger les tabs

        //for (int i = 0; i < heroGroupController.CharactersInstance.Count; i++)
        //{
        //    tabsInstance[i] = new GameObject[2];

        //    for (int j = 0; j < 2; j++)
        //    {
        //        tabsInstance[i][j] = Instantiate(contentLayoutPrefabs, tabViewport);
        //    }
        //    foreach (var stance in ((CharacterData)heroGroupController.CharactersInstance[i].Data).StancesLoadout)
        //    {
        //        var btnInstance = Instantiate(buttonModelPrefabs, tabsInstance[i][1].transform);
        //        InitializeButton(btnInstance, stance);
        //        // parametrer le button
        //    }
        //    for (int j = 0; j < 2; j++)
        //    {
        //        tabsInstance[i][j].SetActive(false);
        //    }
        //}
        //itemsTabs = Instantiate(contentLayoutPrefabs, tabViewport);
        //itemsTabs.SetActive(false);
        //tabsInstance[0][0].SetActive(true);
    }

    internal void SetActiveButton(Outline stanceButton)
    {
        if (activeBtnOutline != null && activeBtnOutline != stanceButton)
        {
            activeBtnOutline.enabled = false;
        }
        activeBtnOutline = stanceButton;
    }

    private void InitializeButton(GameObject btnInstance, StanceData stance)
    {
        btnInstance.GetComponentInChildren<Image>().sprite = stance.StanceIcon;
        var btn = btnInstance.GetComponent<StanceButton>();
        btn.GroupController = heroGroupController;
        btn.ListController = this;
        btn.StanceData = stance;
    }


    internal void SwitchCharacter()
    {
    }
}

