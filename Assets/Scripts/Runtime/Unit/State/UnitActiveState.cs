public class UnitActiveState : UnitState
{
    public delegate void StateTransitionDelegate(UnitController unit);
    public static event StateTransitionDelegate OnStateEnter;

    public override void Awake()
    {
        base.Awake();
        StateName = "Active";
    }

    public override void EnterState()
    {
        OnStateEnter(_manager.Controller);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        
    }
}
