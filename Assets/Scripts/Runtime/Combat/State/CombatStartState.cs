using System.Collections;
using UnityEngine;

public class CombatStartState : CombatState
{
    public delegate void StateTransitionDelegate();
    public static event StateTransitionDelegate OnStateEnter;

    public override void Awake()
    {
        base.Awake();
        StateName = "Battle Start";
    }

    public override void EnterState()
    {
        OnStateEnter();
        StartCoroutine(ShowBattleStartMessage());
    }

    public override void ExitState()
    {

    }

    public override void OnCellClick(int cellIndex, int buttonIndex)
    {

    }

    public override void OnUnitClick(UnitController unit, int buttonIndex)
    {
    
    }

    public override void OnUnitMouseEnter(UnitController unit)
    {

    }

    public override void OnUnitMouseExit(UnitController unit)
    {

    }

    IEnumerator ShowBattleStartMessage()
    {
        HudUiController hud = FindObjectOfType<HudUiController>();
        hud.EnableBattleStartMessage();

        yield return new WaitForSecondsRealtime(3);

        hud.DisableBattleStartMessage();

        _manager.TransitionToState(_manager.PlayerPlacementState);
    }

    public override void UpdateState()
    {

    }
}
