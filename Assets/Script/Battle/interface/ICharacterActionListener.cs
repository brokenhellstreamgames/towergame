public interface ICharacterActionListener
{
    public abstract void OnCharacterPositionReset(BattleCharacterController character);
    public abstract void OnCharacterDeath(BattleCharacterController character);
    public abstract void OnCharacterTakeDamage(BattleCharacterController character, float damage);
}
public enum ActionType
{
    RESET,
    DAMAGE,
    DEATH
}