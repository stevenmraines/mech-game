using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Common.States;
using System;
using System.Collections.Generic;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike
{
    public class PreemptiveStrikeGraph
    {
        private CombatStateManager _manager;
        private Dictionary<CombatState, CombatState[]> _stateGraph;
        private CombatState _initialState;

        public PreemptiveStrikeGraph(CombatStateManager manager)
        {
            _manager = manager;

            _initialState = _manager.BattleStart;

            _stateGraph = new Dictionary<CombatState, CombatState[]>()
            {
                { _manager.BattleStart, new CombatState[] { _manager.PlayerPlacement } },
                { _manager.PlayerPlacement, new CombatState[] { _manager.EnemyPlacement } },
                { _manager.EnemyPlacement, new CombatState[] { _manager.PlayerTurn } }
            };
        }

        public CombatState GetNextState()
        {
            if(_manager.CurrentState == null)
                return _initialState;

            if(!_stateGraph.ContainsKey(_manager.CurrentState))
                throw new ArgumentException("State graph does not contain state of type " + _manager.CurrentState.GetType().Name);

            int numberOfNextStates = _stateGraph[_manager.CurrentState].Length;

            if(numberOfNextStates == 0)
                return null;

            if(numberOfNextStates == 1)
                return _stateGraph[_manager.CurrentState][0];

            foreach(CombatState state in _stateGraph[_manager.CurrentState])
            {
                TransitionValidator<CombatState> validator = GetValidator(state);

                if(validator == null)
                    continue;

                if(validator.ValidateTransition(state))
                    return state;
            }

            return null;
        }
        
        TransitionValidator<CombatState> GetValidator(CombatState state)
        {
            Type stateType = state.GetType();

            if(stateType == typeof(PlayerPlacementState))
                return new TransitionValidators.PlayerPlacement.Validator();

            return null;
        }
    }
}