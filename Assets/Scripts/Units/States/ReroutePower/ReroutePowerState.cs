using RainesGames.Units.Abilities.CancelReroutePower;
using RainesGames.Units.Abilities.ReroutePower;

namespace RainesGames.Units.States.ReroutePower
{
    public class ReroutePowerState : AbsUnitState
    {
        private ReroutePowerAbility _rerouteAbility;
        public ReroutePowerAbility RerouteAbility => _rerouteAbility;

        private CancelReroutePowerAbility _cancelRerouteAbility;
        public CancelReroutePowerAbility CancelRerouteAbility => _cancelRerouteAbility;

        public ReroutePowerState(UnitStateManager manager) : base(manager)
        {
            _rerouteAbility = _manager.Controller.GetAbility<ReroutePowerAbility>();
            _cancelRerouteAbility = _manager.Controller.GetAbility<CancelReroutePowerAbility>();
        }

        public override bool CanEnterState()
        {
            return _rerouteAbility != null && _cancelRerouteAbility != null && _rerouteAbility.ActionIsAffordable();
        }

        public override void EnterState()
        {
            _manager.Controller.PowerManager.RecordOldState();
        }

        public override void ExitState()
        {
            _manager.Controller.PowerManager.DiscardOldState();
        }
    }
}