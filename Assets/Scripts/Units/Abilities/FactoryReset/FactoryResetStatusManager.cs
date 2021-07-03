namespace RainesGames.Units.Abilities.FactoryReset
{
    public class FactoryResetStatusManager : AbsAbilityStatusManager
    {
        public delegate void AbilityStatusDelegate();
        public event AbilityStatusDelegate OnActivate;

        public override void Activate(int duration)
        {
            base.Activate(duration);
            OnActivate?.Invoke();
        }
    }
}