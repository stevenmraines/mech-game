namespace RainesGames.Common.Power
{
    public class PowerManager
    {
        private int _power = 0;

        public void AddPower(int power, int maxPower)
        {
            if(_power + power <= maxPower)
                _power += power;
        }

        public int GetPower()
        {
            return _power;
        }

        public void RemovePower(int power)
        {
            if(_power - power >= 0)
                _power -= power;
        }
    }
}