namespace RainesGames.Units
{
    public class MechController : UnitController
    {
        private int _baseMovement = 6;
        
        public int GetMovement()
        {
            return _baseMovement;
        }
    }
}