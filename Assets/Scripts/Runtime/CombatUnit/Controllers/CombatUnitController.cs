using UnityEngine;

public class CombatUnitController : MonoBehaviour, ICombatUnitController
{
    public CombatUnitStateController _state { get; set; }

    void Awake()
    {
        _state = GetComponent<CombatUnitStateController>();
    }
}
