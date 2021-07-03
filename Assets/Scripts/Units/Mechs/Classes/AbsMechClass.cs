using UnityEngine;

namespace RainesGames.Units.Mechs.Classes
{
    public abstract class AbsMechClass : MonoBehaviour, IMechClass
    {
        protected abstract DataMechClass GetData();

        public virtual int GetBaseMovement()
        {
            return GetData().BaseMovement;
        }

        public virtual string GetClassName()
        {
            return GetData().ClassName;
        }
    }
}