public abstract class WeaponState : State
{
    protected WeaponStateManager _manager;

    public virtual void Awake()
    {
        _manager = GetComponent<WeaponStateManager>();
    }
}
