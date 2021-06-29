using UnityEngine;

namespace RainesGames.Units.Abilities.FactoryReset
{
    [DisallowMultipleComponent]
    public class FactoryResetStatusManager : AbsAbilityStatusManager
    {
        public override void Activate()
        {
            base.Activate();
            _controller.ForceSpendAllAbilityPoints();
        }
    }
}