using RainesGames.Grid;
using RainesGames.UI;
using System.Collections;
using UnityEngine;

namespace RainesGames.Combat.States.BattleStart
{
    public class BattleStartState : CombatState
    {
        protected override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            StateName = "Battle Start";
        }

        public override void EnterState()
        {
            GridManager.DisableCellHighlight();
            StartCoroutine(ShowBattleStartMessage());
        }

        public override void ExitState()
        {

        }

        IEnumerator ShowBattleStartMessage()
        {
            HudUiController hud = FindObjectOfType<HudUiController>();
            hud.EnableBattleStartMessage();

            yield return new WaitForSecondsRealtime(3);

            hud.DisableBattleStartMessage();

            Manager.AttemptTransition();
        }

        public override void UpdateState()
        {

        }
    }
}