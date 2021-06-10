namespace RainesGames.Units.Abilities
{
    public abstract class AStatusManager
    {
        protected UnitController _controller;

        protected bool _active = false;
        public bool Active => _active;

        protected int _statusDuration = 1;
        public int StatusDuration => _statusDuration;

        protected int _turnsRemaining = 0;
        public int TurnsRemaining => _turnsRemaining;

        public AStatusManager(UnitController controller)
        {
            _controller = controller;
        }

        public virtual void Activate()
        {
            _active = true;
            _turnsRemaining = _statusDuration;
        }

        protected virtual void Countdown()
        {
            if(!_active)
                return;

            _turnsRemaining--;

            if(_turnsRemaining == 0)
                _active = false;
        }
    }
}