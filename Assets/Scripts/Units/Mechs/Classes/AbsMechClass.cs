using UnityEngine;

namespace RainesGames.Units.Mechs.Classes
{
    public abstract class AbsMechClass : MonoBehaviour, IMechClass
    {
        public abstract int GetBaseMovement();
        public abstract string GetClassName();
        public abstract int GetMaxPower();
        public abstract int GetStartOfTurnActionPoints();
    }
}