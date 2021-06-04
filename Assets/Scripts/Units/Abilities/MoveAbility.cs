using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    public class MoveAbility : AAbility
    {
        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
        }

        public void Move(Cell cell)
        {
            if(_controller.ActionPointsManager.ActionPoints == 0)
                return;

            if(UnitPositionManager.CellIsOccupied(cell))
            {
                Debug.Log("Cannot move to occupied cell");
                return;
            }

            _controller.PositionManager.PlaceUnit(cell);
            DecrementActionPoints();
        }
    }
}