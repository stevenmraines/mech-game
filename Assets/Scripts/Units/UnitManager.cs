﻿using RainesGames.Combat.States;
using RainesGames.Units.Abilities;
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
            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return;

            CombatStateManager combat = FindObjectOfType<CombatStateManager>();

            if(combat.CurrentState == combat.PlayerTurn && activeUnit.IsEnemy())
                return;

            if(combat.CurrentState == combat.EnemyTurn && activeUnit.IsPlayer())
                return;

            UnitStateManager stateManager = activeUnit.StateManager;

            if(Input.GetMouseButtonUp(1))
                stateManager.TransitionToState(stateManager.Move);

            AbsAbility[] abilities = AbilityTraySort.SortAbilities(activeUnit.GetAbilities());

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
                if(intKeyCodeMap.ContainsKey(i) && Input.GetKeyUp(intKeyCodeMap[i]))
                    stateManager.TransitionToState(abilities[i].State);
            }
        }
    }
}