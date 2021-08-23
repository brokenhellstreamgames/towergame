using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private CraftingUIController craftingUI;
    [SerializeField] private GameObject mainUI;

    private ShopController shopController;

    public ShopController GetShopController => shopController;

    private void Start()
    {
        shopController = GameObject.FindGameObjectWithTag("ShopController").GetComponent<ShopController>();
    }

    public void OnCrafterSelected(int crafterID)
    {
        Debug.Log(crafterID);
        mainUI.SetActive(false);
        //craftingUI.SetActive(shopController.CrafterList[crafterID].Data);
    }

    public void OpenMainMenu()
    {

    }
}
