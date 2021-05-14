public class UnitActiveState : UnitState
{
    public delegate void UnitActiveStateDelegate(StateController stateController);
    public static event UnitActiveStateDelegate ActiveStateEntered;

    public override void EnterState(StateController stateController)
    {
        ActiveStateEntered(stateController);
    }

    public override void ExitState(StateController stateController)
    {

    }

    public override void Update(StateController stateController)
    {
        
    }
}
