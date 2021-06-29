using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(AbsUnit))]
    public abstract class AbsAbilityStatusManager : MonoBehaviour, IAbilityStatusManager
    {
        /*
         * Some tight coupling between ability status managers and units
         * should be okay, since only units can have ability statuses.
         */
        protected AbsUnit _controller;

        protected bool _active = false;
        public bool Active => _active;

        // TODO StatusDuration should come from a scriptable object
        protected int _statusDuration = 1;
        public int StatusDuration => _statusDuration;

        protected int _turnsRemaining = 0;
        public int TurnsRemaining => _turnsRemaining;

        protected virtual void Awake()
        {
            _controller = GetComponent<AbsUnit>();
        }

        public virtual void Activate()
        {
            _active = true;
            _turnsRemaining = _statusDuration;
        }

        public virtual void Countdown()
        {
            if(!_active)
                return;

            _turnsRemaining--;

            if(_turnsRemaining == 0)
                _active = false;
        }
    }
}