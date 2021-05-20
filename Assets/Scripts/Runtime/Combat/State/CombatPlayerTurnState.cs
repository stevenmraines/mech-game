using TGS;

public class CombatPlayerTurnState : CombatState
{
    public delegate void StateTransitionDelegate();
    public static event StateTransitionDelegate OnStateEnter;
    public static event StateTransitionDelegate OnStateUpdate;

    public override void Awake()
    {
        base.Awake();
        StateName = "Player Turn";
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

    }

    public override void OnUnitClick(UnitController unit, int buttonIndex)
    {

    }

    public override void OnUnitMouseEnter(UnitController unit)
    {

    }

    public override void OnUnitMouseExit(UnitController unit)
    {

    }

    public override void UpdateState()
    {
        OnStateUpdate();
    }
}
