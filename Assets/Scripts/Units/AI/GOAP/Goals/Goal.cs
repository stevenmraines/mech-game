using UnityEngine;

namespace RainesGames.Units.AI.GOAP.Goals
{
    public abstract class Goal : MonoBehaviour
    {
        protected string _desiredEffect;
        public string DesiredEffect => _desiredEffect;
    }
}