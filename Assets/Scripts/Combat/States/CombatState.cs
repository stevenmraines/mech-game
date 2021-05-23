using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Combat.States
{
    public abstract class CombatState : State
    {
        [HideInInspector] public CombatStateManager Manager;

        public CellEventHandler CellEventHandler;
        public UnitEventHandler UnitEventHandler;

        protected virtual void Awake()
        {
            Manager = GetComponent<CombatStateManager>();
        }
    }
}