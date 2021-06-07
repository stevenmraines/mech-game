using RainesGames.Combat.States;
using RainesGames.Units;
using RainesGames.Units.Selection;
using RainesGames.Units.States;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.UI
{
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private CombatStateManager _combatStateManager;
        [SerializeField] private GUISkin _centeredLabel;

        private ISelectablesProvider _selectablesProvider;

        void Awake()
        {
            _selectablesProvider = GetComponent<ISelectablesProvider>();
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

        void DrawUnitStatus()
        {
            GUI.skin = null;

            List<UnitController> selectables = _selectablesProvider.GetSelectables();

            int j = 0;

            for(int i = 0; i < selectables.Count; i++)
            {
                string unitName = selectables[i].name + "  -  (AP: " + selectables[i].ActionPointsManager.ActionPoints + ")";

                UnitStateManager stateManager = selectables[i].StateManager;
                AUnitState currentState = stateManager.CurrentState;

                if(currentState == stateManager.NoActionPoints)
                    unitName += "  -  State: No AP";
                
                if(currentState == stateManager.Move)
                    unitName += "  -  State: Move";
                
                if(currentState == stateManager.Hack)
                    unitName += "  -  State: Hack";

                int x = 10;
                int width = 300;
                int height = 20;

                GUI.Label(new Rect(x, GetY(i, j), width, height), unitName);

                if(selectables[i].IsHacked())
                {
                    j++;
                    GUI.Label(new Rect(x, GetY(i, j), width, height), "\tHACKED (" + selectables[i].HackingManager.TurnsRemaining + ")");
                }

                if(selectables[i] == UnitSelectionManager.ActiveUnit)
                {
                    j++;
                    GUI.Label(new Rect(x, GetY(i, j), width, height), "\tACTIVE");
                }
            }
        }

        int GetY(int i, int j)
        {
            return (i + j) * 20 + 50;
        }

        void OnGUI()
        {
            DrawCombatState();
            DrawUnitStatus();
        }
    }
}