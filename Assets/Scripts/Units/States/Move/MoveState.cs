using RainesGames.Grid;
using RainesGames.Units.Abilities.Move;
using UnityEngine;

namespace RainesGames.Units.States.Move
{
    public class MoveState : MonoBehaviour, IUnitState, ICellTargetState
    {
        private ICellEvents _cellEventHandler;
        public ICellEvents CellEventHandler => _cellEventHandler;

        void Awake()
        {
            _cellEventHandler = new CellEventHandler();
        }

        public bool CanEnterState(UnitController unit)
        {
            MoveAbility ability = unit.GetAbility<MoveAbility>();
            return ability != null && ability.AbilityIsAffordable();
        }

        public void EnterState(UnitController unit) { }

        public void ExitState(UnitController unit) { }
    }
}