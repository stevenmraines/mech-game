using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    public class ActionPointsManager : IActionPoints, IActionPointsDynamic
    {
        private int _actionPoints;
        public int ActionPoints => _actionPoints;

        private UnitController _controller;
        public UnitController Controller => _controller;

        private bool _firstActionSpent = false;
        public bool FirstActionSpent => _firstActionSpent;

        private int _startOfTurnActionPoints = 2;
        public int StartOfTurnActionPoints => _startOfTurnActionPoints;

        public delegate void ActionPointsDelegate();
        public event ActionPointsDelegate OnActionPointsDecrement;
        public static event ActionPointsDelegate OnActionPointsDecrementStatic;

        public ActionPointsManager(UnitController controller)
        {
            _controller = controller;

            ResetActionPoints();

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
            _actionPoints -= points;
            _firstActionSpent = true;

            OnActionPointsDecrement?.Invoke();
            OnActionPointsDecrementStatic?.Invoke();
        }

        public void ForceSpendAllActionPoints()
        {
            _actionPoints = 0;
            _firstActionSpent = true;
        }

        public void Increment(int points = 1)
        {
            _actionPoints += points;
        }

        void OnEnterStateEnemyTurn()
        {
            if(_controller.IsEnemy())
                ResetActionPoints();
        }

        void OnEnterStatePlayerTurn()
        {
            if(_controller.IsPlayer())
                ResetActionPoints();
        }

        public void ResetActionPoints()
        {
            if(_controller.IsFactoryReset())
                return;

            int resetAmount = _startOfTurnActionPoints;

            if(_controller.IsUnderclocked())
                resetAmount = Mathf.Max(0, _startOfTurnActionPoints - 1);  // TODO Make this and overclock stackable?

            _actionPoints = resetAmount;
            _firstActionSpent = false;
        }
    }
}