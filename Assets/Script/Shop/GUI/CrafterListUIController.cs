using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CrafterListUIController : MonoBehaviour
{
    [SerializeField] private ShopUIController shopUIController = default;
    [SerializeField] private GameObject crafterUIPrefabs = default;

    private void Start()
    {
        var shop = shopUIController.GetShopController;
        for (int i = 0; i < shop.CrafterList.Count; i++)
        {
               var instance = Instantiate(crafterUIPrefabs, this.transform).GetComponent<Button>();
            instance.onClick.AddListener(() => shopUIController.OnCrafterSelected(i-1));
            instance.GetComponentInChildren<Image>().sprite = shop.CrafterList[i].Data.Portrait;
            instance.GetComponentInChildren<Text>().text = shop.CrafterList[i].Data.name;
        }
    }
}
