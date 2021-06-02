using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Units.AI.GOAP.States
{
    [RequireComponent(typeof(IdleState))]
    [RequireComponent(typeof(MoveWithinRangeState))]
    [RequireComponent(typeof(PerformActionState))]
    public class GoapStateManager : StateManager<GoapState>
    {
        [HideInInspector] public IdleState Idle;
        [HideInInspector] public MoveWithinRangeState MoveWithinRange;
        [HideInInspector] public PerformActionState PerformAction;

        void Awake()
        {
            Idle = GetComponent<IdleState>();
            MoveWithinRange = GetComponent<MoveWithinRangeState>();
            PerformAction = GetComponent<PerformActionState>();
        }
    }
}