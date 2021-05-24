using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Units.States;
using System.Collections.Generic;
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

        public static bool AllEnemyUnitsPlaced()
        {
            return AllUnitsPlaced(GetEnemyUnits());
        }

        public static bool AllPlayerUnitsPlaced()
        {
            return AllUnitsPlaced(GetPlayerUnits());
        }

        static bool AllUnitsPlaced(List<UnitController> units)
        {
            foreach(UnitController unit in units)
            {
                if(!unit.PositionManager.IsPlaced)
                    return false;
            }

            return true;
        }

        void Awake()
        {
            _units = FindObjectsOfType<UnitController>();
        }

        public static List<UnitController> GetEnemyUnits()
        {
            return GetUnitsWithTag(ENEMY_TAG);
        }
        
        public static List<UnitController> GetPlayerUnits()
        {
            return GetUnitsWithTag(PLAYER_TAG);
        }

        static List<UnitController> GetUnitsWithTag(string tag)
        {
            List<UnitController> playerUnits = new List<UnitController>();

            foreach(UnitController unit in _units)
            {
                if(unit.gameObject.CompareTag(tag))
                    playerUnits.Add(unit);
            }

            return playerUnits;
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

        // TODO Handle setting all units to idle with an event or something
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