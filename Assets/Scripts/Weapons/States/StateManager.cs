using UnityEngine;

namespace RainesGames.Weapons.States
{
    public class StateManager : Common.States.StateManager
    {
        [SerializeField] public IdleState IdleState;
        [SerializeField] public TargetingState TargetingState;

        //private WeaponController _controller;
        //public WeaponController Controller { get => _controller; }

        void Awake()
        {
            //_controller = GetComponent<UnitController>();
        }

        public override void NextState()
        {

        }

        void Start()
        {
            TransitionToState(IdleState);
        }
    }
}