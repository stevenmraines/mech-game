using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    public class ActionPointsManager
    {
        private int _abilityPoints;
        public int AbilityPoints => _abilityPoints;

        private UnitController _controller;
        public UnitController Controller => _controller;

        private bool _firstAbilitySpent = false;
        public bool FirstAbilitySpent => _firstAbilitySpent;

        private int _startOfTurnAbilityPoints = 2;
        public int StartOfTurnAbilityPoints => _startOfTurnAbilityPoints;

        public delegate void AbilityPointsDelegate();
        public event AbilityPointsDelegate OnAbilityPointsDecrement;
        public event AbilityPointsDelegate OnAbilityPointsIncrement;
        public static event AbilityPointsDelegate OnAbilityPointsDecrementStatic;

        public ActionPointsManager(UnitController controller)
        {
            _controller = controller;

            ResetAbilityPoints();

            EnemyTurnState.OnEnterState += OnEnterStateEnemyTurn;
            PlayerTurnState.OnEnterState += OnEnterStatePlayerTurn;
        }

        ~ActionPointsManager()
        {
            EnemyTurnState.OnEnterState -= OnEnterStateEnemyTurn;
            PlayerTurnState.OnEnterState -= OnEnterStatePlayerTurn;
        }

        public void Decrement(int points = 1)
        {
            _abilityPoints -= points;
            _firstAbilitySpent = true;

            OnAbilityPointsDecrement?.Invoke();
            OnAbilityPointsDecrementStatic?.Invoke();
        }

        public void ForceSpendAllAbilityPoints()
        {
            _abilityPoints = 0;
            _firstAbilitySpent = true;
        }

        public void Increment(int points = 1)
        {
            _abilityPoints += points;
            OnAbilityPointsIncrement?.Invoke();
        }

        void OnEnterStateEnemyTurn()
        {
            if(_controller.IsEnemy())
                ResetAbilityPoints();
        }

        void OnEnterStatePlayerTurn()
        {
            if(_controller.IsPlayer())
                ResetAbilityPoints();
        }

        public void ResetAbilityPoints()
        {
            if(_controller.IsFactoryReset())
                return;

            int resetAmount = _startOfTurnAbilityPoints;

            // TODO move this to some kind of GetAbilityPointsResetAmount method
            if(_controller.IsUnderclocked())
                resetAmount = Mathf.Max(0, _startOfTurnAbilityPoints - 1);  // TODO Make this and overclock stackable?

            _abilityPoints = resetAmount;
            _firstAbilitySpent = false;
        }
    }
}