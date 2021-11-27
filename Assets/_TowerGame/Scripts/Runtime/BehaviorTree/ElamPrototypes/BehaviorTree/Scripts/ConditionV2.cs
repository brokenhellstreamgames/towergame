using UnityEngine;

[System.Serializable]
public abstract class ConditionV2 : ScriptableObject
{
    public abstract bool Check(Entity entity);
}
