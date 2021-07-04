namespace RainesGames.Units.Usables.Abilities
{
    public class FiniteUseManager
    {
        private int _usesRemaining;

        public void Decrement()
        {
            if(_usesRemaining > 0)
                _usesRemaining--;
        }

        public int GetUsesRemaining()
        {
            return _usesRemaining;
        }

        public void SetUsesRemaining(int numberOfUses)
        {
            _usesRemaining = numberOfUses;
        }
    }
}