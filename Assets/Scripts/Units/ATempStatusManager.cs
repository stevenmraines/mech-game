namespace RainesGames.Units
{
    public abstract class ATempStatusManager
    {
        protected UnitController _controller;

        protected bool _active = false;
        public bool Active => _active;

        protected int _turnsRemaining = 0;
        public int TurnsRemaining => _turnsRemaining;

        public ATempStatusManager(UnitController controller)
        {
            _controller = controller;
        }

        protected abstract void Countdown();
    }
}