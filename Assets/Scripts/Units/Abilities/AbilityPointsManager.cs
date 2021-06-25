using UnityEngine;

namespace RainesGames.Units.Abilities
{
    public class AbilityPointsManager : MonoBehaviour
    {
        public delegate void AbilityPointsDelegate(UnitController unit);
        public event AbilityPointsDelegate OnAbilityPointsDecrement;
        public event AbilityPointsDelegate OnAbilityPointsIncrement;
        
        public delegate void AbilityPointsDelegateStatic();
        public static event AbilityPointsDelegateStatic OnAbilityPointsDecrementStatic;

        public void Decrement(UnitController unit, int points = 1)
        {
            unit.AbilityPoints = Mathf.Max(0, unit.AbilityPoints - points);
            unit.FirstAbilitySpent = true;

            OnAbilityPointsDecrement?.Invoke(unit);
            OnAbilityPointsDecrementStatic?.Invoke();
        }

        public void ForceSpendAllAbilityPoints(UnitController unit)
        {
            unit.AbilityPoints = 0;
            unit.FirstAbilitySpent = true;
        }

        public void Increment(UnitController unit, int points = 1)
        {
            unit.AbilityPoints += points;
            OnAbilityPointsIncrement?.Invoke(unit);
        }

        public void ResetAbilityPoints(UnitController unit)
        {
            if(unit.IsFactoryReset())
                return;

            int resetAmount = unit.StartOfTurnAbilityPoints;

            // TODO move this to some kind of GetAbilityPointsResetAmount method
            if(unit.IsUnderclocked())
                resetAmount = Mathf.Max(0, unit.StartOfTurnAbilityPoints - 1);  // TODO Make this and overclock stackable?

            unit.AbilityPoints = resetAmount;
            unit.FirstAbilitySpent = false;
        }
    }
}