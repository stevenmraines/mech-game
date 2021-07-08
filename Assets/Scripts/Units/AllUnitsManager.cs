using RainesGames.Combat.States;
using RainesGames.Units.Selection;
using System.Collections.Generic;
using RainesGames.Units.Usables;
using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.Move;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units
{
    public class AllUnitsManager : MonoBehaviour
    {
        private static IList<IUnit> _units;
        public static IList<IUnit> Units => _units;

        public const string ENEMY_TAG = "Enemy";
        public const string PLAYER_TAG = "Player";

        static bool AllActionPointsSpent(IList<IUnit> units)
        {
            foreach(IUnit unit in units)
            {
                if(unit.GetActionPoints() > 0)
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

        static bool AllUnitsPlaced(IList<IUnit> units)
        {
            foreach(IUnit unit in units)
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

        public static IList<IUnit> GetEnemyUnits()
        {
            IList<IUnit> enemyUnits = new List<IUnit>();

            foreach(IUnit unit in _units)
            {
                if(unit.IsEnemy())
                    enemyUnits.Add(unit);
            }

            return enemyUnits;
        }
        
        public static IList<IUnit> GetPlayerUnits()
        {
            IList<IUnit> playerUnits = new List<IUnit>();

            foreach(IUnit unit in _units)
            {
                if(unit.IsPlayer())
                    playerUnits.Add(unit);
            }

            return playerUnits;
        }

        void Update()
        {
            // TODO remove all this crap
            IUnit activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return;

            CombatStateManager combat = FindObjectOfType<CombatStateManager>();

            if(combat.CurrentState == combat.PlayerTurn && activeUnit.IsEnemy())
                return;

            if(combat.CurrentState == combat.EnemyTurn && activeUnit.IsPlayer())
                return;

            bool reroutingPower = activeUnit.GetActiveUsable().GetType() == typeof(ReroutePowerAbility);

            if(!reroutingPower && Input.GetMouseButtonUp(1))
                activeUnit.SetActiveUsable(activeUnit.GetAbility<MoveAbility>());

            IList<IAbility> abilities = UsableTraySort.GetSortedAbilities(activeUnit);

            if(abilities.Count == 0)
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

            for(int i = 0; i < abilities.Count; i++)
            {
                if(!reroutingPower && intKeyCodeMap.ContainsKey(i) && Input.GetKeyUp(intKeyCodeMap[i]))
                    activeUnit.SetActiveUsable(abilities[i]);
            }
        }
    }
}