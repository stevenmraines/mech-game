using RainesGames.Grid;
using RainesGames.UI;
using System.Collections;
using UnityEngine;

namespace RainesGames.Combat.States.BattleStart
{
    public class BattleStartState : AbsCombatState
    {
        protected override void Awake()
        {
            base.Awake();
            _stateName = "Battle Start";
        }

        public override void EnterState()
        {
            base.EnterState();
            GridWrapper.DisableCellHighlight();
            StartCoroutine(ShowBattleStartMessage());
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        IEnumerator ShowBattleStartMessage()
        {
            HudUiController hud = FindObjectOfType<HudUiController>();
            hud.EnableBattleStartMessage();

            yield return new WaitForSecondsRealtime(2);

            hud.DisableBattleStartMessage();

            _manager.AttemptTransition();
        }

        public override void UpdateState() { }
    }
}