using UnityEngine;

namespace RainesGames.Units.States.NoAbilityPoints
{
    public class NoAbilityPointsState : MonoBehaviour, IUnitState
    {
        public bool CanEnterState(UnitController unit)
        {
            return unit.AbilityPoints == 0;
        }

        public void EnterState(UnitController unit) { }

        public void ExitState(UnitController unit) { }
    }
}