using RainesGames.Combat.States;
using RainesGames.Selection;
using RainesGames.Units.States;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.UI
{
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private Combat.States.CombatStateManager _combatStateManager;
        [SerializeField] private SelectionManager _selectionManager;
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

            GUI.Label(
                new Rect(Screen.width / 2 - 150, 10, 300, 40),
                _combatStateManager.CurrentState.StateName
            );
        }

        void DrawUnitStatus()
        {
            GUI.skin = null;

            List<GameObject> selectables = _selectablesProvider.GetSelectables();

            for(int i = 0; i < selectables.Count; i++)
            {
                string unitString = selectables[i].name;

                if(_selectionManager.CurrentSelection == selectables[i])
                    unitString += " - HOVERED";

                Units.States.UnitStateManager stateManager = selectables[i].GetComponent<Units.States.UnitStateManager>();

                if(stateManager.CurrentState == stateManager.ActiveState)
                    unitString += " - ACTIVE";

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