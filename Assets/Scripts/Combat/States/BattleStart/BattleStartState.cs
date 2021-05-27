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
            _stateName = "Battle Start";
        }

        public override void EnterState()
        {
            base.EnterState();
            GridManager.DisableCellHighlight();
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

            yield return new WaitForSecondsRealtime(3);

            hud.DisableBattleStartMessage();

            Manager.AttemptTransition();
        }

        public override void UpdateState()
        {
            if(!_entered)
                return;
        }
    }
}