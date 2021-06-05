using RainesGames.Units.Abilities;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(UnitStateManager))]
    public class UnitController : MonoBehaviour
    {
        protected ActionPointsManager _actionPointsManager;
        public ActionPointsManager ActionPointsManager => _actionPointsManager;

        protected Renderer _renderer;
        public Renderer Renderer => _renderer;
        
        protected UnitPositionManager _positionManager;
        public UnitPositionManager PositionManager => _positionManager;

        protected UnitStateManager _stateManager;
        public UnitStateManager StateManager => _stateManager;

        protected void Awake()
        {
            _actionPointsManager = new ActionPointsManager(this);
            _positionManager = new UnitPositionManager(this);
            _renderer = GetComponent<Renderer>();
            _stateManager = GetComponent<UnitStateManager>();
        }

        public T GetAbility<T>() where T : AAbility
        {
            return GetComponent<T>();
        }

        public bool HasAbility<T>() where T : AAbility
        {
            return GetAbility<T>() != null;
        }

        public bool IsEnemy()
        {
            return gameObject.CompareTag(UnitManager.ENEMY_TAG);
        }

        public bool IsPlayer()
        {
            return gameObject.CompareTag(UnitManager.PLAYER_TAG);
        }
    }
}