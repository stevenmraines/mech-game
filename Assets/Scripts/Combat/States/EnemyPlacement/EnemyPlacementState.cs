﻿using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class EnemyPlacementState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            StateName = "Enemy Unit Placement";
        }

        public override void EnterState()
        {
            GridManager.EnableCellHighlight();
        }

        public override void ExitState()
        {
            OnExitState?.Invoke();
        }

        public override void UpdateState()
        {
            UnitSelectionManager.UpdateSelection();
        }
    }
}