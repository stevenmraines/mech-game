using System.Collections.Generic;

namespace RainesGames.Units.AI.GOAP.Actions
{
    public class MoveWithinRangeOfUnit : AAction
    {
        const string WITHIN_RANGE_OF_UNIT = "withinRangeOfUnit";

        protected override void Awake()
        {
            base.Awake();

            _effects = new Dictionary<string, object>()
            {
                { WITHIN_RANGE_OF_UNIT, true }
            };
        }

        public bool CheckPreconditions()
        {
            return HasEnoughActionPoints();
        }
    }
}