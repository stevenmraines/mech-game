using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(AbsUnit))]
    public abstract class AbsAbilityStatusManager : IAbilityStatusManager
    {
        protected bool _active = false;
        protected int _turnsRemaining = 0;

        public virtual void Activate(int duration)
        {
            _active = true;
            _turnsRemaining = duration;
        }

        public virtual void Countdown()
        {
            if(!_active)
                return;

            _turnsRemaining--;

            if(_turnsRemaining == 0)
                _active = false;
        }

        public virtual bool IsActive()
        {
            return _active;
        }

        public virtual int GetTurnsRemaining()
        {
            return _turnsRemaining;
        }
    }
}