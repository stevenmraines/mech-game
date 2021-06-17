using RainesGames.Combat.States;
using RainesGames.Common.Power;
using RainesGames.Units;
using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.CancelReroutePower;
using RainesGames.Units.Abilities.ReroutePower;
using RainesGames.Units.Selection;
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

            AbsAbility[] abilities = AbilityTraySort.GetSortedUnitAbilities(activeUnit);

            if(abilities.Length == 0)
                return;

            for(int i = 0; i < abilities.Length; i++)
                DrawAbilityButton(i, abilities, activeUnit);

            DrawBattery(activeUnit);
        }

        void DrawAbilityButton(int i, AbsAbility[] abilities, UnitController activeUnit)
        {
            AbsAbility ability = abilities[i];

            int buttonX = GetAbilityButtonX(i, abilities.Length);
            int buttonY = Screen.height - 110;
            int buttonWidth = 50;
            int buttonHeight = buttonWidth;

            Rect buttonPosition = new Rect()
            {
                x = buttonX,
                y = buttonY,
                width = buttonWidth,
                height = buttonHeight
            };

            string abilityName = ability.GetType().Name;
            string abilityNameTrimmed = abilityName.Substring(0, abilityName.Length - 7);

            GUIContent content = new GUIContent()
            {
                text = i + 1 < 10 ? (i + 1).ToString() : (i + 1 > 10 ? "" : "0"),
                tooltip = abilityNameTrimmed
            };

            bool isPowered = ability is IPowerContainerInteractable;
            bool reroutingPower = activeUnit.StateManager.CurrentState == activeUnit.StateManager.ReroutePower;
            bool canEnterState = ability.State.CanEnterState();
            bool canRerouteAbilityPower = reroutingPower && isPowered;
            bool abilityIsUsable = !reroutingPower && canEnterState;

            GUI.enabled = canRerouteAbilityPower || abilityIsUsable;
            
            if(GUI.Button(buttonPosition, content))
            {
                if(canRerouteAbilityPower)
                {
                    HandlePowerReroute(activeUnit, ability);
                }
                
                if(abilityIsUsable)
                {
                    HandleUseAbility(activeUnit, ability);
                }
            }

            GUI.enabled = true;

            int tooltipWidth = 90;
            int tooltipHeight = 20;
            int tooltipX = buttonX + (buttonWidth / 2) - (tooltipWidth / 2);
            int tooltipY = buttonY - tooltipHeight;

            Rect tooltipPosition = new Rect()
            {
                x = tooltipX,
                y = tooltipY,
                width = tooltipWidth,
                height = tooltipHeight
            };

            if(GUI.tooltip + "Ability" == ability.GetType().Name)
                GUI.Label(tooltipPosition, GUI.tooltip);

            if(activeUnit.StateManager.CurrentState == activeUnit.StateManager.ReroutePower)
                DrawReroutePowerButtons(activeUnit);

            if(!(ability is IPowerContainerInteractable))
                return;

            DrawAbilityPower(ability, buttonPosition);
        }

        void DrawAbilityPower(AbsAbility ability, Rect buttonPosition)
        {
            int power = GetAbilityPower(ability);
            int maxPower = GetAbilityMaxPower(ability);
            int powerBarWidth = 12;
            int powerBarHeight = powerBarWidth;
            int gutterHeight = 5;

            for(int j = 1; j <= maxPower; j++)
            {
                float abilityButtonYOffset = buttonPosition.y + buttonPosition.height;
                int previousPowerBarsOffset = (j - 1) * powerBarHeight;
                int gutters = (j - 1) * gutterHeight;
                int y = (int)abilityButtonYOffset + previousPowerBarsOffset + gutters;

                Rect powerBarPosition = new Rect()
                {
                    x = buttonPosition.x + buttonPosition.width / 2 - 7,
                    y = y,
                    width = powerBarWidth,
                    height = powerBarHeight
                };

                bool powered = j <= power;

                GUI.Toggle(powerBarPosition, powered, "");
            }
        }

        void DrawBattery(UnitController activeUnit)
        {
            GUIContent content = new GUIContent()
            {
                text = "Battery"
            };

            Rect labelPosition = new Rect()
            {
                x = Screen.width - 50,
                y = Screen.height - 30,
                width = 50,
                height = 20
            };

            GUI.Label(labelPosition, content);

            for(int i = 1; i <= activeUnit.PowerManager.MaxPower; i++)
            {
                Rect powerBarPosition = new Rect()
                {
                    x = Screen.width - 30,
                    y = labelPosition.y - 5 - i * 25,
                    width = 20,
                    height = 20
                };

                bool powered = i <= activeUnit.PowerManager.Power;

                GUI.Toggle(powerBarPosition, powered, "");
            }
        }

        void DrawReroutePowerButtons(UnitController activeUnit)
        {
            int gutter = 10;

            Rect confirmButtonPosition = new Rect()
            {
                x = Screen.width / 2 - 100 - gutter / 2,
                y = Screen.height - 190,
                width = 100,
                height = 50
            };

            GUIContent content = new GUIContent()
            {
                text = "Confirm"
            };

            if(GUI.Button(confirmButtonPosition, content))
                activeUnit.GetAbility<ReroutePowerAbility>().Execute();

            Rect cancelButtonPosition = new Rect()
            {
                x = confirmButtonPosition.x + confirmButtonPosition.width + gutter / 2,
                y = confirmButtonPosition.y,
                width = confirmButtonPosition.width,
                height = confirmButtonPosition.height
            };
                
            content.text = "Cancel";

            if(GUI.Button(cancelButtonPosition, content))
                activeUnit.GetAbility<CancelReroutePowerAbility>().Execute();
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

        int GetAbilityMaxPower(AbsAbility ability)
        {
            if(!(ability is IPowerContainerInteractable))
                return 0;

            return ((IPowerContainerInteractable)ability).MaxPower;
        }
        
        int GetAbilityPower(AbsAbility ability)
        {
            if(!(ability is IPowerContainerInteractable))
                return 0;

            return ((IPowerContainerInteractable)ability).Power;
        }

        int GetAbilityMinPower(AbsAbility ability)
        {
            if(!(ability is IPoweredItem))
                return 0;

            return ((IPoweredItem)ability).MinPower;
        }

        void HandlePowerReroute(UnitController activeUnit, AbsAbility ability)
        {
            int power = Mathf.Max(1, GetAbilityMinPower(ability));

            if(Input.GetMouseButtonUp(0))
            {
                activeUnit.PowerManager.TransferPowerTo(((IPowerContainerInteractable)ability), power);
            }

            if(Input.GetMouseButtonUp(1))
            {
                activeUnit.PowerManager.TransferPowerFrom(((IPowerContainerInteractable)ability), power);
            }
        }

        void HandleUseAbility(UnitController activeUnit, AbsAbility ability)
        {
            activeUnit.StateManager.TransitionToState(ability.State);
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