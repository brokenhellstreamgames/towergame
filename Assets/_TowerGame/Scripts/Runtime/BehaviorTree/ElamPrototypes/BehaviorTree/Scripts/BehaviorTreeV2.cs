using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorTreeV2 : MonoBehaviour
{
    public List<BehaviorTreeItemV2> items;

    private Entity _entity;

    public BehaviorTreeItemV2 GetTreeItem(Entity originEntity)
    {
        BehaviorTreeItemV2 treeItem = items.FirstOrDefault(i => i.IsActive && i.CheckConditions(originEntity) && i.Ability.CanBeUsed(originEntity));
        if (treeItem == null)
        {
            items.ForEach(i => i.Enable());
        }
        
        treeItem = items.FirstOrDefault(i => i.IsActive && i.CheckConditions(originEntity) && i.Ability.CanBeUsed(originEntity));

        if (treeItem == null)
        {
            throw new Exception();
        }
        return treeItem;
    }
}
