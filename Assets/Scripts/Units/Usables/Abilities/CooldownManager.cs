namespace RainesGames.Units.Usables.Abilities
{
    public class CooldownManager
    {
        private int _cooldown = 0;

        public void Cooldown()
        {
            if(_cooldown > 0)
                _cooldown--;
        }

        public int GetCooldown()
        {
            return _cooldown;
        }

        public void SetCooldown(int duration)
        {
            _cooldown = duration;
        }
    }
}