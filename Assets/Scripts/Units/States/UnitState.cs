using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Units.States
{
    public abstract class UnitState : State
    {
        [HideInInspector] public UnitStateManager Manager;

        public virtual void Awake()
        {
            Manager = GetComponent<UnitStateManager>();
        }
    }
}