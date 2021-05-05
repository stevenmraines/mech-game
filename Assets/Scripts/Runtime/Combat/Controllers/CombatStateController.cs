using System;

public class CombatStateController : StateController
{
    public State combatStartState = new CombatStartState();
    public State enemyTurnState = new CombatEnemyTurnState();
    public State placementState = new CombatUnitPlacementState();
    public State playerLostState = new CombatPlayerLostState();
    public State playerTurnState = new CombatPlayerTurnState();
    public State playerWonState = new CombatPlayerWonState();

    void Start()
    {
        currentState = combatStartState;
        TransitionToState(placementState);
    }

    public override void TransitionToState(State state)
    {
        if(!typeof(CombatState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of CombatState");
        }

        base.TransitionToState(state);
    }
}
