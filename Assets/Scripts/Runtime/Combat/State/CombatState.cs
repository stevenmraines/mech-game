using TGS;

public abstract class CombatState : State, ICombatState
{
    protected CombatStateManager _manager;

    public virtual void Awake()
    {
        _manager = GetComponent<CombatStateManager>();
    }

    public abstract void OnCellClick(int cellIndex, int buttonIndex);
    public abstract void OnUnitClick(UnitController unit, int buttonIndex);
    public abstract void OnUnitMouseEnter(UnitController unit);
    public abstract void OnUnitMouseExit(UnitController unit);
}
