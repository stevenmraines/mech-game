namespace RainesGames.Units.Usables
{
    public class ActiveUsableManager
    {
        private IUsable _activeUsable;

        void Activate(IUsable usable)
        {
            if(usable != null && usable is IActivatableUsable)
                ((IActivatableUsable)usable).Activate();
        }

        public void ClearActiveUsable()
        {
            Deactivate(_activeUsable);
            _activeUsable = null;
        }

        void Deactivate(IUsable usable)
        {
            if(usable != null && usable is IDeactivatableUsable)
                ((IDeactivatableUsable)usable).Deactivate();
        }

        public IUsable GetActiveUsable()
        {
            return _activeUsable;
        }

        public void SetActiveUsable(IUsable usable)
        {
            Deactivate(_activeUsable);
            _activeUsable = usable;
            Activate(_activeUsable);
        }
    }
}