using TGS;
using UnityEngine;

namespace RainesGames.Units.Usables
{
    public class EnemyUnitTargetRangedValidator : IUnitTargetRangedUsableValidator
    {
        public bool IsValid(IUnit activeUnit, IUnit targetUnit, IRangedUsable usable)
        {
            Cell targetUnitPosition = targetUnit.GetPosition();
            
            if(targetUnitPosition == null || !usable.InRange(targetUnitPosition))
            {
                Debug.Log("Target unit not in range");
                return false;
            }

            return true;
        }
    }
}
