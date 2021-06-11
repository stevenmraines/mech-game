using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Move;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.States;
using System.Collections.Generic;
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

        protected UnderclockStatusManager _underclockStatusManager;
        public UnderclockStatusManager UnderclockStatusManager => _underclockStatusManager;

        protected void Awake()
        {
            _factoryResetStatusManager = new FactoryResetStatusManager(this);
            _hackStatusManager = new HackStatusManager(this);
            _underclockStatusManager = new UnderclockStatusManager(this);
            _actionPointsManager = new ActionPointsManager(this);
            _positionManager = new UnitPositionManager(this);
            _renderer = GetComponent<Renderer>();
            _stateManager = new UnitStateManager(this);
        }

        public T GetAbility<T>() where T : AbsAbility
        {
            return GetComponent<T>();
        }

        public AbsAbility[] GetAbilities(bool filterMove = true)
        {
            AbsAbility[] abilities = gameObject.GetComponents<AbsAbility>();

            if(!filterMove)
                return abilities;

            List<AbsAbility> filteredAbilities = new List<AbsAbility>();

            foreach(AbsAbility ability in abilities)
            {
                if(ability.GetType() != typeof(MoveAbility))
                    filteredAbilities.Add(ability);
            }

            return filteredAbilities.ToArray();
        }

        public bool HasAbility<T>() where T : AbsAbility
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

        // TODO maybe split all these convenience methods out into a partial class or something
        public bool IsUnderclocked()
        {
            return _underclockStatusManager.Active;
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