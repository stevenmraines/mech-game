using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units
{
    public class UnitManager : MonoBehaviour
    {
        private static UnitController[] _units;
        public static UnitController[] Units { get => _units; }

        private static UnitController _activeUnit;
        public static UnitController ActiveUnit { get => _activeUnit; }

        public const string PLAYER_TAG = "Player";
        public const string ENEMY_TAG = "Enemy";

        void Awake()
        {
            _units = FindObjectsOfType<UnitController>();
        }

        void OnDisable()
        {
            ActiveState.OnEnterState -= SetActiveUnit;
            EnemyPlacementState.OnExitState -= SetAllUnitsToIdle;
            PlayerPlacementState.OnExitState -= SetAllUnitsToIdle;
        }

        void OnEnable()
        {
            ActiveState.OnEnterState += SetActiveUnit;
            EnemyPlacementState.OnExitState += SetAllUnitsToIdle;
            PlayerPlacementState.OnExitState += SetAllUnitsToIdle;
        }

        void SetActiveUnit(UnitController unit)
        {
            _activeUnit = unit;
        }

        // TODO There may be a better way to do this, with events or something, and Unit states may not be needed at all
        void SetAllUnitsToIdle()
        {
            foreach(UnitController unit in _units)
            {
                unit.StateManager.TransitionToState(unit.StateManager.Idle);
            }

            SetActiveUnit(null);
        }
    }
}