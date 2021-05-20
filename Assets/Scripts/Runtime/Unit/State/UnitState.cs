public abstract class UnitState : State
{
    protected UnitStateManager _manager;

    public virtual void Awake()
    {
        _manager = GetComponent<UnitStateManager>();
    }
}
