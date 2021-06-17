namespace RainesGames.Units.Abilities
{
    public abstract class AbsStatusManager
    {
        protected UnitController _controller;

        protected bool _active = false;
        public bool Active => _active;

        // TODO StatusDuration should come from a scriptable object
        protected int _statusDuration = 1;
        public int StatusDuration => _statusDuration;

        protected int _turnsRemaining = 0;
        public int TurnsRemaining => _turnsRemaining;

        public AbsStatusManager(UnitController controller)
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