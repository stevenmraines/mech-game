namespace RainesGames.Weapons.States
{
    public abstract class State : Common.States.State
    {
        protected StateManager _manager;

        public virtual void Awake()
        {
            _manager = GetComponent<StateManager>();
        }
    }
}