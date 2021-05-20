using UnityEngine;

public class WeaponStateManager : StateManager
{
    [SerializeField] public WeaponIdleState IdleState;
    [SerializeField] public WeaponTargetingState TargetingState;

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
