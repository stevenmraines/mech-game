using UnityEngine;

public class UnitController : MonoBehaviour, IUnitController
{
    public UnitStateController _state { get; set; }

    void Awake()
    {
        _state = GetComponent<UnitStateController>();
    }
}
