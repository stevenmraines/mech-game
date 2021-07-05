namespace RainesGames.Units.Usables.Abilities.Hack
{
    public class HackStatusManager : AbsAbilityStatusManager
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