using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorTree
{
    public List<BehaviorTreeItem> items;

    private Entity _entity;

    public BehaviorTree(Entity entity)
    {
        _entity = entity;
        items = new List<BehaviorTreeItem>
        {
            new BehaviorTreeItem(entity, 0),
            new BehaviorTreeItem(entity, 1),
            new BehaviorTreeItem(entity, 2)
        };
    }

    public BehaviorTreeItem GetTreeItem()
    {
        BehaviorTreeItem treeItem = items.FirstOrDefault(i => i.IsActive && i.Condition.Check() && i.Ability.CanBeUsed());
        if (treeItem == null)
        {
            items.ForEach(i => i.Enable());
        }
        
        treeItem = items.FirstOrDefault(i => i.IsActive && i.Condition.Check() && i.Ability.CanBeUsed());

        if (treeItem == null)
        {
            throw new Exception();
        }
        
        return treeItem;
    }
}
