public class CombatPlayerPlacementState : CombatState
{
    public delegate void StateDelegate();
    public static event StateDelegate OnStateEnter;
    public static event StateDelegate OnStateUpdate;

    public override void Awake()
    {
        base.Awake();
        StateName = "Player Unit Placement";
    }

    public override void EnterState()
    {
        OnStateEnter();
    }

    public override void ExitState()
    {
        
    }

    public override void OnCellClick(int cellIndex, int buttonIndex)
    {
        if(UnitManager.ActiveUnit == null)
            return;

        UnitManager.ActiveUnit.PositionManager.SetCell(GridManager.GetCell(cellIndex));
    }

    public override void OnUnitMouseEnter(UnitController unit)
    {
        // TODO Figure out how to use lambda expressions for these one line event handlers
        GridManager.DisableCellHighlight();
    }

    public override void OnUnitMouseExit(UnitController unit)
    {
        GridManager.EnableCellHighlight();
    }

    public override void OnUnitClick(UnitController unit, int buttonIndex)
    {
        if(unit.IsEnemy())
            return;

        unit.StateManager.TransitionToState(unit.StateManager.ActiveState);
    }

    public override void UpdateState()
    {
        OnStateUpdate();
    }
}
