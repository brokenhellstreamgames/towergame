using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class ItemLoader
{
    private ItemData[] helmet, glove, shoes, chest;
    private ItemData[] oneHanded, twoHanded;
    private ItemData[] bow, throwable;
    private ItemData[] shield, quiver;
    private ItemData[] amulet, ring;
    private ItemData[] consumable;


    public ItemData[] GetItem(ItemCategory filter)
    {
        switch (filter)
        {
            case ItemCategory.ONE_HANDED_WEAPON:
                return LoadData(oneHanded, "OneHanded");
            case ItemCategory.TWO_HANDED_WEAPON:
                return LoadData(twoHanded, "TwoHanded");
            case ItemCategory.HELMET:
                return LoadData(helmet, "Helmet");
            case ItemCategory.GLOVE:
                return LoadData(glove, "Glove");
            case ItemCategory.SHOES:
                return LoadData(shoes, "Shoes");
            case ItemCategory.CHEST:
                return LoadData(chest, "Chest");
            case ItemCategory.AMULET:
                 return LoadData(amulet, "Amulet");
            case ItemCategory.RING:
                 return LoadData(ring, "Ring");
            case ItemCategory.CONSUMABLE:
                return LoadData(consumable, "Consumable");
        }
        throw new NotImplementedException();
    }

    private ItemData[] LoadData(ItemData[] data, string path)
    {
        if(data == null)
        {
            data = Resources.LoadAll("Items/"+path, typeof(ItemData)).Cast<ItemData>().ToArray();
        }
        return data;
    }
}