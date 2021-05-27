using UnityEngine;

namespace RainesGames.Common.States
{
    public abstract class State : MonoBehaviour
    {
        protected bool _entered = false;
        public bool Entered => _entered;

        protected string _stateName;
        public string StateName => _stateName;

        public virtual void EnterState()
        {
            _entered = true;
        }

        public virtual void ExitState()
        {
            _entered = false;
        }

        public abstract void UpdateState();
    }
}