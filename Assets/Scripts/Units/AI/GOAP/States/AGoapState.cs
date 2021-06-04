using RainesGames.Common.States;

namespace RainesGames.Units.AI.GOAP.States
{
    public abstract class AGoapState : IState
    {
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
    }
}