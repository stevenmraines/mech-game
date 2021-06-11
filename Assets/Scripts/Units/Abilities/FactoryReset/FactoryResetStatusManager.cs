﻿using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;

namespace RainesGames.Units.Abilities.FactoryReset
{
    public class FactoryResetStatusManager : AStatusManager
    {
        public FactoryResetStatusManager(UnitController controller) : base(controller)
        {
            EnemyTurnState.OnExitState += OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState += OnExitStatePlayerTurn;
        }

        ~FactoryResetStatusManager()
        {
            EnemyTurnState.OnExitState -= OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState -= OnExitStatePlayerTurn;
        }

        public override void Activate()
        {
            base.Activate();
            _controller.ActionPointsManager.ForceSpendAllActionPoints();
        }

        private void OnExitStateEnemyTurn()
        {
            if(_controller.IsEnemy())
                Countdown();
        }

        private void OnExitStatePlayerTurn()
        {
            if(_controller.IsPlayer())
                Countdown();
        }
    }
}