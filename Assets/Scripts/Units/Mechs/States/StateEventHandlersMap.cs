using RainesGames.Grid;
using RainesGames.Units.States;
using System.Collections.Generic;

namespace RainesGames.Units.Mechs.States
{
    public class StateEventHandlersMap
    {
        private Dictionary<UnitState, ICellEvents> _cellHandlers;
        private Dictionary<UnitState, IStateChangeEvents> _stateChangeHandlers;
        private Dictionary<UnitState, IUnitEvents> _unitHandlers;

        public StateEventHandlersMap()
        {
            _cellHandlers = new Dictionary<UnitState, ICellEvents>()
            {
                { UnitState.MOVE, new Move.CellEventHandler() }
            };

            _stateChangeHandlers = new Dictionary<UnitState, IStateChangeEvents>()
            {
                { UnitState.REROUTE_POWER, new ReroutePower.StateChangeEventHandler() }
            };

            _unitHandlers = new Dictionary<UnitState, IUnitEvents>()
            {
                { UnitState.FACTORY_RESET, new FactoryReset.UnitEventHandler() },
                { UnitState.HACK, new Hack.UnitEventHandler() },
                { UnitState.OVERCLOCK, new Overclock.UnitEventHandler() },
                { UnitState.UNDERCLOCK, new Underclock.UnitEventHandler() }
            };
        }

        public ICellEvents GetCellHandler(UnitState state)
        {
            if(_cellHandlers.ContainsKey(state))
                return _cellHandlers[state];

            return null;
        }

        public IStateChangeEvents GetStateChangeHandler(UnitState state)
        {
            if(_stateChangeHandlers.ContainsKey(state))
                return _stateChangeHandlers[state];

            return null;
        }
        
        public IUnitEvents GetUnitHandler(UnitState state)
        {
            if(_unitHandlers.ContainsKey(state))
                return _unitHandlers[state];

            return null;
        }
    }
}