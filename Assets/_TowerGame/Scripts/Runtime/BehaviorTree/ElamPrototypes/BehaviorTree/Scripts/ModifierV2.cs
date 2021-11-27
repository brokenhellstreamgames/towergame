using UnityEngine;

[System.Serializable]
public abstract class ModifierV2 : ScriptableObject
{   
    //public Entity Entity;
    
    //public ModifierV2(Entity entity)
    //{
    //    Entity = entity;
    //}
    
    public abstract void ModifyAbility(AbilityInstance ability);
}