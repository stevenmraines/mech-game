using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Units.States;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units
{
    // TODO RequireComponent UnitSelectionManager?
    public class UnitManager : MonoBehaviour
    {
        private static UnitController _activeUnit;
        public static UnitController ActiveUnit => _activeUnit;

        private static UnitController[] _units;
        public static UnitController[] Units => _units;

        public const string ENEMY_TAG = "Enemy";
        public const string PLAYER_TAG = "Player";

        static bool AllActionPointsSpent(List<UnitController> units)
        {
            foreach(UnitController unit in units)
            {
                if(unit.ActionPointsManager.ActionPoints > 0)
                    return false;
            }

            return true;
        }

        public static bool AllEnemyActionPointsSpent()
        {
            return AllActionPointsSpent(GetEnemyUnits());
        }
        
        public static bool AllPlayerActionPointsSpent()
        {
            return AllActionPointsSpent(GetPlayerUnits());
        }

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
            EnemyTurnState.OnEnterState -= ResetAllEnemyActionPoints;
            PlayerTurnState.OnEnterState -= ResetAllPlayerActionPoints;
            EnemyPlacementState.OnExitState -= ResetActiveUnit;
            PlayerPlacementState.OnExitState -= ResetActiveUnit;
        }

        void OnEnable()
        {
            ActiveState.OnEnterState += SetActiveUnit;
            EnemyTurnState.OnEnterState += ResetAllEnemyActionPoints;
            PlayerTurnState.OnEnterState += ResetAllPlayerActionPoints;
            EnemyPlacementState.OnExitState += ResetActiveUnit;
            PlayerPlacementState.OnExitState += ResetActiveUnit;
        }

        void ResetActiveUnit()
        {
            SetActiveUnit(null);
        }

        public static void ResetAllEnemyActionPoints()
        {
            ResetAllUnitActionPoints(GetEnemyUnits());
        }

        public static void ResetAllPlayerActionPoints()
        {
            ResetAllUnitActionPoints(GetPlayerUnits());
        }

        static void ResetAllUnitActionPoints(List<UnitController> units)
        {
            foreach(UnitController unit in units)
                unit.ActionPointsManager.ResetActionPoints();
        }

        void SetActiveUnit(UnitController unit)
        {
            _activeUnit = unit;
        }
    }
}