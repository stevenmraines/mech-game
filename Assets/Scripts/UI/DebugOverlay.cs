using System.Collections.Generic;
using RainesGames.Combat.States;
using RainesGames.Common.Power;
using RainesGames.Units;
using RainesGames.Units.Selection;
using RainesGames.Units.Usables;
using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.ReloadRightHandWeapon;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using RainesGames.Units.Usables.Weapons;
using UnityEngine;

namespace RainesGames.UI
{
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private CombatStateManager _combatStateManager;
        [SerializeField] private GUISkin _centeredLabel;
        [SerializeField] private GUISkin _medTextLabel;

        void DrawAmmo()
        {
            IUnit activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return;

            IUsable activeUsable = activeUnit.GetActiveUsable();

            if(activeUsable == null || !(activeUsable is IAmmoWeapon))
                return;

            IAmmoWeapon weapon = ((IAmmoWeapon)activeUsable);

            string weaponName = activeUsable.GetName();
            int shotsPerClip = weapon.GetShotsPerClip();
            int clipsRemaining = weapon.GetClipsRemaining();
            int shotsRemaining = weapon.GetShotsRemaining();

            GUI.skin = _medTextLabel;

            int height = 30;
            int width = 150;
            int x = 20;
            int y = Screen.height - 100;

            GUI.Label(
                new Rect(x, y, width, height),
                weaponName + $" ({clipsRemaining})"
            );

            int buttonWidth = 50;
            height = buttonWidth;
            width = buttonWidth;
            y += 30;

            GUIContent content = new GUIContent()
            {
                text = "",
                tooltip = ""
            };

            for(int i = 1; i <= shotsPerClip; i++)
            {
                if(i > shotsRemaining)
                    GUI.enabled = false;

                GUI.Button(
                    new Rect(x, y, width, height),
                    content
                );

                x += buttonWidth;
            }

            GUI.enabled = true;
        }

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

        void DrawConfirmUseButtons(IUnit activeUnit, int offsetFromBottom)
        {
            //int gutter = 10;
            int width = 100;
            int height = 50;
            //int x = Screen.width / 2 - width - gutter / 2;
            int x = Screen.width / 2 - width / 2;
            //int y = offsetFromBottom - height - gutter;
            int y = offsetFromBottom - height;

            Rect confirmButtonPosition = new Rect(x, y, width, height);

            GUIContent content = new GUIContent()
            {
                text = "Reload"
            };

            if(GUI.Button(confirmButtonPosition, content))
                activeUnit.GetUsable<ReloadRightHandWeaponAbility>().Use();
        }

        void DrawUsables()
        {
            GUI.skin = null;

            IUnit activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return;

            IList<IUsable> usables = activeUnit.GetTrayUsables();

            if(usables.Count == 0)
                return;

            for(int i = 0; i < usables.Count; i++)
                DrawUsableButton(i, usables, activeUnit);

            DrawBattery(activeUnit);
        }

        void DrawUsableButton(int i, IList<IUsable> usables, IUnit activeUnit)
        {
            IUsable usable = usables[i];

            int buttonX = GetUsableButtonX(i, usables.Count);
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

            string usableName = usable.GetType().Name;

            GUIContent content = new GUIContent()
            {
                text = i + 1 < 10 ? (i + 1).ToString() : (i + 1 > 10 ? "" : "0"),
                tooltip = usableName
            };

            bool isPowered = usable is IPowerContainerInteractable;
            bool reroutingPower = activeUnit.GetActiveUsable()?.GetType() == typeof(ReroutePowerAbility);
            bool canBeUsed = usable.CanBeUsed();
            bool canRerouteUsablePower = reroutingPower && isPowered;
            bool usableCanBeUsed = !reroutingPower && canBeUsed;

            GUI.enabled = canRerouteUsablePower || usableCanBeUsed;
            
            if(GUI.Button(buttonPosition, content))
            {
                if(canRerouteUsablePower)
                {
                    HandlePowerReroute(activeUnit, usable);
                }
                
                if(usableCanBeUsed)
                {
                    HandleUseUsable(activeUnit, usable);
                }
            }

            GUI.enabled = true;

            int tooltipHeightIncrement = 20;
            int tooltipWidth = 120;
            int tooltipHeight = tooltipHeightIncrement;
            int tooltipX = buttonX + (buttonWidth / 2) - (tooltipWidth / 2);
            int tooltipY = buttonY - tooltipHeight;
            string tooltip = GUI.tooltip;

            if(usable is IFiniteUseManagerClient)
            {
                IFiniteUseManagerClient finiteUseUsable = ((IFiniteUseManagerClient)usable);

                tooltipHeight += tooltipHeightIncrement;
                tooltipY -= tooltipHeightIncrement;
                tooltip += "\nUses: " + finiteUseUsable.GetUsesRemaining();
            }

            if(usable is ICooldownManagerClient)
            {
                ICooldownManagerClient cooldownUsable = ((ICooldownManagerClient)usable);

                if(cooldownUsable.NeedsCooldown())
                {
                    tooltipHeight += tooltipHeightIncrement;
                    tooltipY -= tooltipHeightIncrement;
                    tooltip += "\nCooldown: " + cooldownUsable.GetCooldown();
                }
            }

            Rect tooltipPosition = new Rect()
            {
                x = tooltipX,
                y = tooltipY,
                width = tooltipWidth,
                height = tooltipHeight
            };

            if(GUI.tooltip == usableName)
                GUI.Label(tooltipPosition, tooltip);

            if(activeUnit.GetActiveUsable()?.GetType() == typeof(ReroutePowerAbility))
            {
                // height inc * 3 = one for regular tooltip, two for cooldown, three for finite use
                int offset = buttonY - tooltipHeightIncrement * 3;
                DrawReroutePowerButtons(activeUnit, offset);
            }

            if(activeUnit.GetActiveUsable()?.GetType() == typeof(ReloadRightHandWeaponAbility))
            {
                int offset = buttonY - tooltipHeightIncrement * 3;
                DrawConfirmUseButtons(activeUnit, offset);
            }

            if(!(usable is IPowerContainerInteractable))
                return;

            DrawUsablePower(usable, buttonPosition);
        }

        void DrawUsablePower(IUsable usable, Rect buttonPosition)
        {
            int power = GetUsablePower(usable);
            int maxPower = GetUsableMaxPower(usable);
            int powerBarWidth = 12;
            int powerBarHeight = powerBarWidth;
            int gutterHeight = 5;

            for(int j = 1; j <= maxPower; j++)
            {
                float usableButtonYOffset = buttonPosition.y + buttonPosition.height;
                int previousPowerBarsOffset = (j - 1) * powerBarHeight;
                int gutters = (j - 1) * gutterHeight;
                int y = (int)usableButtonYOffset + previousPowerBarsOffset + gutters;

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

        void DrawBattery(IUnit activeUnit)
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

            for(int i = 1; i <= activeUnit.GetMaxPower(); i++)
            {
                Rect powerBarPosition = new Rect()
                {
                    x = Screen.width - 30,
                    y = labelPosition.y - 5 - i * 25,
                    width = 20,
                    height = 20
                };

                bool powered = i <= activeUnit.GetPower();

                GUI.Toggle(powerBarPosition, powered, "");
            }
        }

        void DrawReroutePowerButtons(IUnit activeUnit, int offsetFromBottom)
        {
            int gutter = 10;
            int width = 100;
            int height = 50;
            int x = Screen.width / 2 - width - gutter / 2;
            int y = offsetFromBottom - height - gutter;

            Rect confirmButtonPosition = new Rect(x, y, width, height);

            GUIContent content = new GUIContent()
            {
                text = "Confirm"
            };

            if(GUI.Button(confirmButtonPosition, content))
                activeUnit.GetUsable<ReroutePowerAbility>().Use();

            Rect cancelButtonPosition = new Rect()
            {
                x = confirmButtonPosition.x + confirmButtonPosition.width + gutter / 2,
                y = confirmButtonPosition.y,
                width = confirmButtonPosition.width,
                height = confirmButtonPosition.height
            };
                
            content.text = "Cancel";

            if(GUI.Button(cancelButtonPosition, content))
                activeUnit.SetFallbackUsable();
        }

        void DrawUnitStatus()
        {
            GUI.skin = _medTextLabel;

            IUnit hoveredUnit = UnitSelectionManager.CurrentSelection;
            IUnit activeUnit = UnitSelectionManager.ActiveUnit;
            IUnit unit = hoveredUnit ?? activeUnit;

            if(unit == null)
                return;

            string unitInfo = ((MonoBehaviour)unit).name + "  (" + unit.GetActionPoints() + ")";

            string stateName = unit.GetActiveUsable()?.GetType().Name;
            unitInfo += "\nState: " + stateName;

            if(unit.IsHacked() || unit.IsFactoryReset() || unit.IsUnderclocked())
            {
                unitInfo += "\nStatus effects:";

                if(unit.IsHacked())
                    unitInfo += "\n\tHacked  (" + unit.GetHackedTurnsRemaining() + ")";

                if(unit.IsFactoryReset())
                    unitInfo += "\n\tFactory Reset  (" + unit.GetFactoryResetTurnsRemaining() + ")";

                if(unit.IsUnderclocked())
                    unitInfo += "\n\tUnderclocked  (" + unit.GetUnderclockedTurnsRemaining() + ")";
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

        int GetUsableButtonX(int i, int numberOfAbilities)
        {
            int center = Screen.width / 2;
            int alreadyDrawnButtonsWidth = i * 50;
            int alreadyDrawnGuttersWidth = i * 10;
            int xPositionInTray = alreadyDrawnButtonsWidth + alreadyDrawnGuttersWidth;
            int numberOfGutters = numberOfAbilities - 1;
            int buttonTrayWidth = numberOfAbilities * 50 + 10 * numberOfGutters;

            return (xPositionInTray + center) - (buttonTrayWidth / 2);
        }

        int GetUsableMaxPower(IUsable usable)
        {
            if(!(usable is IPowerContainerInteractable))
                return 0;

            return ((IPowerContainerInteractable)usable).GetMaxPower();
        }
        
        int GetUsablePower(IUsable usable)
        {
            if(!(usable is IPowerContainerInteractable))
                return 0;

            return ((IPowerContainerInteractable)usable).GetPower();
        }

        int GetUsableMinPower(IUsable usable)
        {
            if(!(usable is IPoweredItem))
                return 0;

            return ((IPoweredItem)usable).GetMinPower();
        }

        void HandlePowerReroute(IUnit activeUnit, IUsable usable)
        {
            int power = Mathf.Max(1, GetUsableMinPower(usable));

            if(Input.GetMouseButtonUp(0))
            {
                activeUnit.TransferPowerTo(((IPowerContainerInteractable)usable), power);
            }

            if(Input.GetMouseButtonUp(1))
            {
                activeUnit.TransferPowerFrom(((IPowerContainerInteractable)usable), power);
            }
        }

        void HandleUseUsable(IUnit activeUnit, IUsable usable)
        {
            activeUnit.SetActiveUsable(usable);
        }

        void OnGUI()
        {
            DrawCombatState();
            DrawUnitStatus();

            if(_combatStateManager.CurrentState == _combatStateManager.PlayerPlacement
                || _combatStateManager.CurrentState == _combatStateManager.EnemyPlacement)
                return;

            DrawUsables();
            DrawAmmo();
        }
    }
}