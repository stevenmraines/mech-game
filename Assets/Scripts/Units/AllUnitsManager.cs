using RainesGames.Combat.States;
using RainesGames.Units.Abilities;
using RainesGames.Units.Selection;
using RainesGames.Units.States;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;
using UnityEngine;

namespace RainesGames.Units
{
    public class AllUnitsManager : MonoBehaviour
    {
        private static AbsUnit[] _units;
        public static AbsUnit[] Units => _units;

        public const string ENEMY_TAG = "Enemy";
        public const string PLAYER_TAG = "Player";

        static bool AllActionPointsSpent(List<AbsUnit> units)
        {
            foreach(AbsUnit unit in units)
            {
                if(unit.GetAbilityPoints() > 0)
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

        static bool AllUnitsPlaced(List<AbsUnit> units)
        {
            foreach(AbsUnit unit in units)
            {
                if(!unit.IsPlaced())
                    return false;
            }

            return true;
        }

        void Awake()
        {
            _units = FindObjectsOfType<AbsUnit>();
        }

        public static List<AbsUnit> GetEnemyUnits()
        {
            List<AbsUnit> enemyUnits = new List<AbsUnit>();

            foreach(AbsUnit unit in _units)
            {
                if(unit.IsEnemy())
                    enemyUnits.Add(unit);
            }

            return enemyUnits;
        }
        
        public static List<AbsUnit> GetPlayerUnits()
        {
            List<AbsUnit> playerUnits = new List<AbsUnit>();

            foreach(AbsUnit unit in _units)
            {
                if(unit.IsPlayer())
                    playerUnits.Add(unit);
            }

            return playerUnits;
        }

        void Update()
        {
            // TODO remove all this crap
            AbsUnit activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return;

            CombatStateManager combat = FindObjectOfType<CombatStateManager>();

            if(combat.CurrentState == combat.PlayerTurn && activeUnit.IsEnemy())
                return;

            if(combat.CurrentState == combat.EnemyTurn && activeUnit.IsPlayer())
                return;

            bool reroutingPower = activeUnit.GetCurrentState() == UnitState.REROUTE_POWER;

            if(!reroutingPower && Input.GetMouseButtonUp(1))
                activeUnit.TransitionToState(UnitState.MOVE);

            AbsAbility[] abilities = AbilityTraySort.GetSortedUnitAbilities(activeUnit);

            if(abilities.Length == 0)
                return;

            Dictionary<int, KeyCode> intKeyCodeMap = new Dictionary<int, KeyCode>()
            {
                { 0, KeyCode.Alpha1 },
                { 1, KeyCode.Alpha2 },
                { 2, KeyCode.Alpha3 },
                { 3, KeyCode.Alpha4 },
                { 4, KeyCode.Alpha5 },
                { 5, KeyCode.Alpha6 },
                { 6, KeyCode.Alpha7 },
                { 7, KeyCode.Alpha8 },
                { 8, KeyCode.Alpha9 },
                { 9, KeyCode.Alpha0 }
            };

            for(int i = 0; i < abilities.Length; i++)
            {
                if(!reroutingPower && intKeyCodeMap.ContainsKey(i) && Input.GetKeyUp(intKeyCodeMap[i]))
                    activeUnit.TransitionToState(abilities[i].GetState());
            }
        }
    }
}