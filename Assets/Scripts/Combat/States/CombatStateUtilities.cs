using System.Collections;
using UnityEngine;

namespace RainesGames.Combat.States
{
    public class CombatStateUtilities
    {
        /**
         * In the event that none of the current team's units have anything to do,
         * i.e. all the units are hacked or something, preemptively try to change state.
         */
        public static IEnumerator NoActionPointsCheck(CombatStateManager manager)
        {
            yield return new WaitForSecondsRealtime(2);
            manager.AttemptTransition();
        }
    }
}