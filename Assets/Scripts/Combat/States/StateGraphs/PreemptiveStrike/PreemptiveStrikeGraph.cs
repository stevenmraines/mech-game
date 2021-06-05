using RainesGames.Common.States;
using System;
using System.Collections.Generic;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike
{
    public class PreemptiveStrikeGraph : IStateGraph  // TODO Probably don't need an interface for this
    {
        private ACombatState _initialState;
        private CombatStateManager _manager;
        private Dictionary<ACombatState, ACombatState[]> _stateGraph;
        private Dictionary<ACombatState, ITransitionValidator> _validators;

        public PreemptiveStrikeGraph(CombatStateManager manager)
        {
            _manager = manager;

            _initialState = _manager.BattleStart;

            _stateGraph = new Dictionary<ACombatState, ACombatState[]>()
            {
                { _manager.BattleStart, new ACombatState[] { _manager.PlayerPlacement } },
                { _manager.PlayerPlacement, new ACombatState[] { _manager.EnemyPlacement } },
                { _manager.EnemyPlacement, new ACombatState[] { _manager.PlayerTurn } },
                { _manager.PlayerTurn, new ACombatState[] { _manager.EnemyTurn } },
                { _manager.EnemyTurn, new ACombatState[] { _manager.PlayerTurn } }
            };

            _validators = new Dictionary<ACombatState, ITransitionValidator>()
            {
                { _manager.BattleStart, new TransitionValidators.BattleStart.Validator() },
                { _manager.PlayerPlacement, new TransitionValidators.PlayerPlacement.Validator() },
                { _manager.EnemyPlacement, new TransitionValidators.EnemyPlacement.Validator() },
                { _manager.PlayerTurn, new TransitionValidators.PlayerTurn.Validator() },
                { _manager.EnemyTurn, new TransitionValidators.EnemyTurn.Validator() }
            };
        }

        public IState GetNextState()
        {
            if(_manager.CurrentState == null)
                return _initialState;

            if(!_stateGraph.ContainsKey(_manager.CurrentState))
                throw new ArgumentException("State graph does not contain state of type " + _manager.CurrentState.GetType().Name);

            // Return value of null indicates a "dead end" state like Player Won or Player Lost
            if(_stateGraph[_manager.CurrentState].Length == 0)
                return null;

            foreach(ACombatState nextState in _stateGraph[_manager.CurrentState])
            {
                ITransitionValidator validator = GetValidator();

                if(validator == null)
                    continue;

                if(validator.IsValid(nextState))
                    return nextState;
            }

            return null;
        }
        
        ITransitionValidator GetValidator()
        {
            if(_validators.ContainsKey(_manager.CurrentState))
                return _validators[_manager.CurrentState];

            return null;
        }
    }
}