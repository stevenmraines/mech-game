using RainesGames.Grid;
using RainesGames.UI;
using RainesGames.Units.Selection;
using System.Collections;
using UnityEngine;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class PlayerTurnState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            StateName = "Player Turn";
        }

        public override void EnterState()
        {
            GridManager.EnableCellHighlight();
            GridManager.DisableTerritories();
            StartCoroutine(TestThing());
        }

        public override void ExitState()
        {
            OnExitState?.Invoke();
        }

        IEnumerator TestThing()
        {
            HudUiController hud = FindObjectOfType<HudUiController>();

            hud.EnablePlayerWonMessage();

            yield return new WaitForSecondsRealtime(3);

            hud.DisablePlayerWonMessage();
        }

        public override void UpdateState()
        {
            UnitSelectionManager.UpdateSelection();
        }
    }
}