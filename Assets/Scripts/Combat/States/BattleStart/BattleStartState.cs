using RainesGames.UI;
using System.Collections;
using UnityEngine;

namespace RainesGames.Combat.States.BattleStart
{
    public class BattleStartState : AbsCombatState
    {
        public delegate void StateChangeDelegate();
        public static event StateChangeDelegate OnEnterState;

        protected override void Awake()
        {
            base.Awake();
            _stateName = "Battle Start";
        }

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke();
            StartCoroutine(ShowBattleStartMessage());
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        IEnumerator ShowBattleStartMessage()
        {
            HudUiController hud = FindObjectOfType<HudUiController>();
            // TODO Toggle message with some events instead of calling it directly
            hud.EnableBattleStartMessage();

            yield return new WaitForSecondsRealtime(2);

            hud.DisableBattleStartMessage();

            _manager.AttemptTransition();
        }

        public override void UpdateState() { }
    }
}