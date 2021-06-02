namespace RainesGames.Units.AI.GOAP.Goals
{
    public class GetWithinRangeOfUnit : Goal
    {
        void Awake()
        {
            _desiredEffect = "withinRangeOfUnit";
        }
    }
}