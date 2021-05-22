using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitPositionManager _positionManager;
        [SerializeField] private UnitStateManager _stateManager;

        private Renderer _renderer;

        public UnitPositionManager PositionManager { get => _positionManager; }
        public Renderer Renderer { get => _renderer; }
        public UnitStateManager StateManager { get => _stateManager; }

        void Awake()
        {
            _renderer = GetComponent<Renderer>();
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