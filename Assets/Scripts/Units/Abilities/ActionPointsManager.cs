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

        public ActionPointsManager(UnitController controller)
        {
            _controller = controller;
            ResetActionPoints();
        }

        public void Decrement(int points = 1)
        {
            _actionPoints -= points;
            _firstActionSpent = true;
        }

        public void Increment(int points = 1)
        {
            _actionPoints += points;
        }

        public void ResetActionPoints()
        {
            _actionPoints = _startOfTurnActionPoints;
            _firstActionSpent = false;
        }
    }
}