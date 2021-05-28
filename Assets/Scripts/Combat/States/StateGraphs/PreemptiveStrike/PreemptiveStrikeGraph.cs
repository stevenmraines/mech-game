using RainesGames.Common.States;
using System;
using System.Collections.Generic;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike
{
    public class PreemptiveStrikeGraph
    {
        private CombatState _initialState;
        private CombatStateManager _manager;
        private Dictionary<CombatState, CombatState[]> _stateGraph;
        private Dictionary<CombatState, TransitionValidator<CombatState>> _validators;

        public PreemptiveStrikeGraph(CombatStateManager manager)
        {
            _manager = manager;

            _initialState = _manager.BattleStart;

            _stateGraph = new Dictionary<CombatState, CombatState[]>()
            {
                { _manager.BattleStart, new CombatState[] { _manager.PlayerPlacement } },
                { _manager.PlayerPlacement, new CombatState[] { _manager.EnemyPlacement } },
                { _manager.EnemyPlacement, new CombatState[] { _manager.PlayerTurn } },
                { _manager.PlayerTurn, new CombatState[] { _manager.EnemyTurn } },
                { _manager.EnemyTurn, new CombatState[] { _manager.PlayerTurn } }
            };

            _validators = new Dictionary<CombatState, TransitionValidator<CombatState>>()
            {
                { _manager.BattleStart, new TransitionValidators.BattleStart.Validator() },
                { _manager.PlayerPlacement, new TransitionValidators.PlayerPlacement.Validator() },
                { _manager.EnemyPlacement, new TransitionValidators.EnemyPlacement.Validator() },
                { _manager.PlayerTurn, new TransitionValidators.PlayerTurn.Validator() },
                { _manager.EnemyTurn, new TransitionValidators.EnemyTurn.Validator() }
            };
        }

        public CombatState GetNextState()
        {
            if(_manager.CurrentState == null)
                return _initialState;

            if(!_stateGraph.ContainsKey(_manager.CurrentState))
                throw new ArgumentException("State graph does not contain state of type " + _manager.CurrentState.GetType().Name);

            // Return value of null indicates a "dead end" state like Player Won or Player Lost
            if(_stateGraph[_manager.CurrentState].Length == 0)
                return null;

            foreach(CombatState nextState in _stateGraph[_manager.CurrentState])
            {
                TransitionValidator<CombatState> validator = GetValidator();

                if(validator == null)
                    continue;

                if(validator.ValidateTransition(nextState))
                    return nextState;
            }

            return null;
        }
        
        TransitionValidator<CombatState> GetValidator()
        {
            if(_validators.ContainsKey(_manager.CurrentState))
                return _validators[_manager.CurrentState];

            return null;
        }
    }
}