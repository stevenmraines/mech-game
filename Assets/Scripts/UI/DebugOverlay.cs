using RainesGames.Combat.States;
using RainesGames.Units;
using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Overclock;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Selection;
using RainesGames.Units.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.UI
{
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private CombatStateManager _combatStateManager;
        [SerializeField] private GUISkin _centeredLabel;
        [SerializeField] private GUISkin _medTextLabel;

        void DrawCombatState()
        {
            if(_combatStateManager.CurrentState == null)
                return;

            GUI.skin = _centeredLabel;

            int height = 40;
            int width = Screen.width - 20;
            int x = Screen.width / 2 - (width / 2);
            int y = 10;

            GUI.Label(
                new Rect(x, y, width, height),
                _combatStateManager.CurrentState.StateName
            );
        }

        void DrawAbilities()
        {
            GUI.skin = null;

            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return;

            AbsAbility[] abilities = AbilityTraySort.SortAbilities(activeUnit.GetAbilities());

            if(abilities.Length == 0)
                return;

            Dictionary<AbsAbility, AbsUnitState> abilityStates = GetAbilityStates(abilities, activeUnit);

            for(int i = 0; i < abilities.Length; i++)
                DrawAbilityButton(i, abilities, activeUnit, abilityStates);
        }

        void DrawAbilityButton(int i, AbsAbility[] abilities, UnitController activeUnit, Dictionary<AbsAbility, AbsUnitState> abilityStates)
        {
            AbsAbility ability = abilities[i];

            Rect buttonPosition = new Rect()
            {
                x = GetAbilityButtonX(i, abilities.Length),
                y = Screen.height - 60,
                width = 50,
                height = 50
            };

            string abilityName = ability.GetType().Name;
            string abilityNameTrimmed = abilityName.Substring(0, abilityName.Length - 7);

            GUIContent content = new GUIContent()
            {
                text = i + 1 < 10 ? (i + 1).ToString() : (i + 1 > 10 ? "" : "0"),
                tooltip = abilityNameTrimmed
            };

            if(GUI.Button(buttonPosition, content) && abilityStates.ContainsKey(ability))
                activeUnit.StateManager.TransitionToState(abilityStates[ability]);

            Rect tooltipPosition = new Rect()
            {
                x = buttonPosition.x + 25 - 45,
                y = Screen.height - 80,
                width = 90,
                height = 20
            };

            if(GUI.tooltip + "Ability" == ability.GetType().Name)
                GUI.Label(tooltipPosition, GUI.tooltip);
        }

        void DrawUnitStatus()
        {
            GUI.skin = _medTextLabel;

            UnitController hoveredUnit = UnitSelectionManager.CurrentSelection;
            UnitController activeUnit = UnitSelectionManager.ActiveUnit;
            UnitController unit = hoveredUnit != null ? hoveredUnit : activeUnit;

            if(unit == null)
                return;

            string unitInfo = unit.name + "  (" + unit.ActionPointsManager.ActionPoints + ")";

            string stateName = unit.StateManager.CurrentState.GetType().Name;
            unitInfo += "\nState: " + stateName.Substring(0, stateName.Length - 5);

            if(unit.IsHacked() || unit.IsFactoryReset() || unit.IsUnderclocked())
            {
                unitInfo += "\nStatus effects:";

                if(unit.IsHacked())
                    unitInfo += "\n\tHacked  (" + unit.HackStatusManager.TurnsRemaining + ")";

                if(unit.IsFactoryReset())
                    unitInfo += "\n\tFactory Reset  (" + unit.FactoryResetStatusManager.TurnsRemaining + ")";

                if(unit.IsUnderclocked())
                    unitInfo += "\n\tUnderclocked  (" + unit.UnderclockStatusManager.TurnsRemaining + ")";
            }

            Rect labelPosition = new Rect()
            {
                x = 10,
                y = 70,
                width = 300,
                height = 126 // 21 pixels per line at 17 pt font
            };

            GUI.Label(labelPosition, unitInfo);
        }

        int GetAbilityButtonX(int i, int numberOfAbilities)
        {
            int center = Screen.width / 2;
            int alreadyDrawnButtonsWidth = i * 50;
            int alreadyDrawnGuttersWidth = i * 10;
            int xPositionInTray = alreadyDrawnButtonsWidth + alreadyDrawnGuttersWidth;
            int numberOfGutters = numberOfAbilities - 1;
            int buttonTrayWidth = numberOfAbilities * 50 + 10 * numberOfGutters;

            return (xPositionInTray + center) - (buttonTrayWidth / 2);
        }

        Dictionary<AbsAbility, AbsUnitState> GetAbilityStates(AbsAbility[] abilities, UnitController activeUnit)
        {
            Dictionary<AbsAbility, AbsUnitState> abilityStates = new Dictionary<AbsAbility, AbsUnitState>();

            foreach(AbsAbility ability in abilities)
            {
                if(ability.GetType() == typeof(FactoryResetAbility))
                    abilityStates.Add(ability, activeUnit.StateManager.FactoryReset);

                if(ability.GetType() == typeof(HackAbility))
                    abilityStates.Add(ability, activeUnit.StateManager.Hack);

                if(ability.GetType() == typeof(OverclockAbility))
                    abilityStates.Add(ability, activeUnit.StateManager.Overclock);

                if(ability.GetType() == typeof(UnderclockAbility))
                    abilityStates.Add(ability, activeUnit.StateManager.Underclock);
            }

            return abilityStates;
        }

        void OnGUI()
        {
            DrawCombatState();
            DrawUnitStatus();

            if(_combatStateManager.CurrentState == _combatStateManager.PlayerPlacement
                || _combatStateManager.CurrentState == _combatStateManager.EnemyPlacement)
                return;

            DrawAbilities();
        }
    }
}