using System.Collections.Generic;

public class BehaviorTreeItem
{
    public Condition Condition;
    public Ability Ability;
    public Modifier Modifier;

    public bool IsActive;

    public BehaviorTreeItem(Entity entity, int index)
    {
        IsActive = true;
        if(index==0) Init0(entity);
        else if(index==1) Init1(entity);
        else Init2(entity);
    }

    private void Init0(Entity entity)
    {
        Condition = new FirstAttack(entity);
        Ability = new BaseAttack(entity);
        Modifier = new Random(entity);
    }

    private void Init1(Entity entity)
    {
        Condition = new TwoOrMoreEntity(entity);
        Ability = new Wave(entity);
        Modifier = new Random(entity);
    }

    private void Init2(Entity entity)
    {
        Condition = new OneEntity(entity);
        Ability = new BaseAttack(entity);
        Modifier = new HPGreatier(entity);
    }

    public void Enable()
    {
        IsActive = true;
    }

    public void Disable()
    {
        IsActive = false;
    }
}
