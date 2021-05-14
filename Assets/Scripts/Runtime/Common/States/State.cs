public abstract class State
{
    public abstract void EnterState(StateController stateController);
    public abstract void ExitState(StateController stateController);
    public abstract void Update(StateController stateController);

    public bool EqualTo(State state)
    {
        return this.GetType() == state.GetType();
    }
}
