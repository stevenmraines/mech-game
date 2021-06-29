using UnityEngine;

namespace RainesGames.Units.Abilities.Hack
{
    [DisallowMultipleComponent]
    public class HackStatusManager : AbsAbilityStatusManager
    {
        public override void Activate()
        {
            base.Activate();
            _controller.ForceSpendAllAbilityPoints();
        }
        
        protected override void Awake()
        {
            base.Awake();
            _statusDuration = 4;
        }
    }
}