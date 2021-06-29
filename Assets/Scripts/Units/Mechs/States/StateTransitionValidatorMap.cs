using RainesGames.Units.States;
using System.Collections.Generic;

namespace RainesGames.Units.Mechs.States
{
    public class StateTransitionValidatorMap
    {
        private Dictionary<UnitState, IStateTransitionValidator> _validators;

        public StateTransitionValidatorMap()
        {
            _validators = new Dictionary<UnitState, IStateTransitionValidator>()
            {
                { UnitState.FACTORY_RESET, new FactoryReset.Validator() },
                { UnitState.HACK, new Hack.Validator() },
                { UnitState.MOVE, new Move.Validator() },
                { UnitState.NO_ABILITY_POINTS, new NoAbilityPoints.Validator() },
                { UnitState.OVERCLOCK, new Overclock.Validator() },
                { UnitState.REROUTE_POWER, new ReroutePower.Validator() },
                { UnitState.UNDERCLOCK, new Underclock.Validator() }
            };
        }

        public IStateTransitionValidator GetValidator(UnitState state)
        {
            if(_validators.ContainsKey(state))
                return _validators[state];

            return null;
        }
    }
}