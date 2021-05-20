using UnityEngine;

public class UnitStateManager : StateManager
{
    [SerializeField] public UnitIdleState IdleState;
    [SerializeField] public UnitActiveState ActiveState;
    [SerializeField] public UnitDestroyedState DestroyedState;
    [SerializeField] public UnitTargetedState TargetedState;

    private UnitController _controller;
    public UnitController Controller { get => _controller; }

    void Awake()
    {
        _controller = GetComponent<UnitController>();
    }

    public override void NextState()
    {
        
    }

    void OnActiveStateEnter(UnitController unit)
    {
        // Can only have one unit active at a time
        if(unit.StateManager != this && _current == ActiveState)
            TransitionToState(IdleState);
    }

    void OnDisable()
    {
        UnitActiveState.OnStateEnter -= OnActiveStateEnter;
    }

    void OnEnable()
    {
        UnitActiveState.OnStateEnter += OnActiveStateEnter;
    }
    
    void Start()
    {
        TransitionToState(IdleState);
    }
}
