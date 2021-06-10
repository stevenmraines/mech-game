using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class UnitController : MonoBehaviour
    {
        protected ActionPointsManager _actionPointsManager;
        public ActionPointsManager ActionPointsManager => _actionPointsManager;

        protected FactoryResetStatusManager _factoryResetStatusManager;
        public FactoryResetStatusManager FactoryResetStatusManager => _factoryResetStatusManager;

        protected HackStatusManager _hackStatusManager;
        public HackStatusManager HackStatusManager => _hackStatusManager;

        protected UnitPositionManager _positionManager;
        public UnitPositionManager PositionManager => _positionManager;
        
        protected Renderer _renderer;
        public Renderer Renderer => _renderer;

        protected UnitStateManager _stateManager;
        public UnitStateManager StateManager => _stateManager;

        protected void Awake()
        {
            _factoryResetStatusManager = new FactoryResetStatusManager(this);
            _hackStatusManager = new HackStatusManager(this);
            _actionPointsManager = new ActionPointsManager(this);
            _positionManager = new UnitPositionManager(this);
            _renderer = GetComponent<Renderer>();
            _stateManager = new UnitStateManager(this);
        }

        public T GetAbility<T>() where T : AAbility
        {
            return GetComponent<T>();
        }

        public bool HasAbility<T>() where T : AAbility
        {
            return GetAbility<T>() != null;
        }

        public bool HasEnemyTag()
        {
            return HasTag(UnitManager.ENEMY_TAG);
        }

        public bool HasPlayerTag()
        {
            return HasTag(UnitManager.PLAYER_TAG);
        }

        public bool HasTag(string tag)
        {
            return gameObject.CompareTag(tag);
        }

        public bool IsEnemy()
        {
            return !IsPlayer();
        }

        public bool IsFactoryReset()
        {
            return _factoryResetStatusManager.Active;
        }

        public bool IsHacked()
        {
            return _hackStatusManager.Active;
        }

        public bool IsPlayer()
        {
            return (HasPlayerTag() && !IsHacked()) || (HasEnemyTag() && IsHacked());
        }

        public bool SameTagAs(UnitController unit)
        {
            return HasTag(unit.gameObject.tag);
        }

        public bool SameTeamAs(UnitController unit)
        {
            return (IsPlayer() && unit.IsPlayer()) || (IsEnemy() && unit.IsEnemy());
        }
    }
}