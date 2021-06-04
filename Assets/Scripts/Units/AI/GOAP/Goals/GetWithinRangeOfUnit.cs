namespace RainesGames.Units.AI.GOAP.Goals
{
    public class GetWithinRangeOfUnit : AGoal
    {
        void Awake()
        {
            _desiredEffect = "withinRangeOfUnit";
        }
    }
}