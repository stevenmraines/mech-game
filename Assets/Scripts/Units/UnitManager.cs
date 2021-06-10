using RainesGames.Units.Selection;
using RainesGames.Units.States;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units
{
    // TODO RequireComponent UnitSelectionManager?
    public class UnitManager : MonoBehaviour
    {
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
            List<UnitController> enemyUnits = new List<UnitController>();

            foreach(UnitController unit in _units)
            {
                if(unit.IsEnemy())
                    enemyUnits.Add(unit);
            }

            return enemyUnits;
        }
        
        public static List<UnitController> GetPlayerUnits()
        {
            List<UnitController> playerUnits = new List<UnitController>();

            foreach(UnitController unit in _units)
            {
                if(unit.IsPlayer())
                    playerUnits.Add(unit);
            }

            return playerUnits;
        }

        void Update()
        {
            // TODO remove all this crap
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            UnitStateManager stateManager = UnitSelectionManager.ActiveUnit.StateManager;

            if(Input.GetMouseButtonUp(1))
                stateManager.TransitionToState(stateManager.Move);

            if(Input.GetKeyUp(KeyCode.Alpha1))
                stateManager.TransitionToState(stateManager.Hack);

            if(Input.GetKeyUp(KeyCode.Alpha2))
                stateManager.TransitionToState(stateManager.FactoryReset);
            
            if(Input.GetKeyUp(KeyCode.Alpha3))
                stateManager.TransitionToState(stateManager.Overclock);
        }
    }
}