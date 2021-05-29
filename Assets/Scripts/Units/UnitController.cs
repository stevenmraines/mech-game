using RainesGames.Units.Actions;
using UnityEngine;

namespace RainesGames.Units
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class UnitController : MonoBehaviour
    {
        private ActionPointsManager _actionPointsManager;
        public ActionPointsManager ActionPointsManager => _actionPointsManager;

        private Renderer _renderer;
        public Renderer Renderer => _renderer;
        
        private UnitPositionManager _positionManager;
        public UnitPositionManager PositionManager => _positionManager;

        void Awake()
        {
            _actionPointsManager = new ActionPointsManager(this);
            _positionManager = new UnitPositionManager(this);
            _renderer = GetComponent<Renderer>();
        }

        public T GetAction<T>() where T : Action
        {
            return GetComponent<T>();
        }

        public bool HasAction<T>() where T : Action
        {
            return GetAction<T>() != null;
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