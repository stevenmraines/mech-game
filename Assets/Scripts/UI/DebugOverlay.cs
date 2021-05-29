using RainesGames.Combat.States;
using RainesGames.Units;
using RainesGames.Units.Selection;
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

            for(int i = 0; i < selectables.Count; i++)
            {
                string unitString = selectables[i].name + " (" + selectables[i].ActionPointsManager.ActionPoints + ")";

                if(selectables[i] == UnitSelectionManager.ActiveUnit)
                    unitString += " - ACTIVE";

                if(UnitSelectionManager.CurrentSelection == selectables[i])
                    unitString += " - HOVERED";

                GUI.Label(new Rect(10, i * 20 + 50, 300, 20), unitString);
            }
        }

        void OnGUI()
        {
            DrawCombatState();
            DrawUnitStatus();
        }
    }
}