using UnityEngine.AI;

namespace RainesGames.Units
{
    // TODO This class isn't needed, things like turrets can simply be distinguished by the lack of Move ability
    public class MechController : UnitController
    {
        protected NavMeshAgent _navMeshAgent;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        private int _baseMovement = 6;

        protected override void Awake()
        {
            base.Awake();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public int GetMovement()
        {
            return _baseMovement;
        }
    }
}