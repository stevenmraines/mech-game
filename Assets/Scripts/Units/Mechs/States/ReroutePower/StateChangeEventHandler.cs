namespace RainesGames.Units.Mechs.States.ReroutePower
{
    public class StateChangeEventHandler : IStateChangeEvents
    {
        public void OnEnterState(AbsUnit unit)
        {
            unit.RecordPowerState();
        }

        public void OnExitState(AbsUnit unit)
        {
            unit.DiscardPowerState();
        }
    }
}