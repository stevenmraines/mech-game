using RainesGames.Common.Power;
using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Position;
using RainesGames.Units.Power;
using RainesGames.Units.States;
using System.Collections.Generic;
using System.Linq;
using RainesGames.Units.Usables.Abilities;
using TGS;
using UnityEngine;

namespace RainesGames.Units
{
    public abstract class AbsUnit : MonoBehaviour, IUnit
    {
        protected AbilityPointsManager _abilityPointsManager;
        protected FactoryResetStatusManager _factoryResetStatusManager;
        protected HackStatusManager _hackStatusManager;
        protected PositionManager _positionManager;
        protected PowerRerouteManager _powerManager;
        protected UnitStateManager _stateManager;
        protected UnderclockStatusManager _underclockStatusManager;

        protected virtual void Awake()
        {
            _abilityPointsManager = new AbilityPointsManager();
            _factoryResetStatusManager = new FactoryResetStatusManager();
            _hackStatusManager = new HackStatusManager();
            _positionManager = new PositionManager();
            _powerManager = new PowerRerouteManager();
            _stateManager = new UnitStateManager();
            _underclockStatusManager = new UnderclockStatusManager();
        }

        public abstract bool CanEnterState(UnitState state);
        public abstract void DecrementAbilityPoints(int points = 1);
        public abstract void DiscardPowerState();
        public abstract void FactoryReset(int duration);
        public abstract bool FirstAbilitySpent();
        public abstract void ForceSpendAllAbilityPoints();
        public abstract int GetAbilityPoints();
        public abstract UnitState GetCurrentState();
        public abstract int GetFactoryResetTurnsRemaining();
        public abstract int GetHackedTurnsRemaining();
        public abstract int GetMaxPower();
        public abstract int GetMovement();
        public abstract Cell GetPosition();
        public abstract int GetPower();
        public abstract int GetStartOfTurnAbilityPoints();
        public abstract int GetUnderclockedTurnsRemaining();
        public abstract void Hack(int duration);
        public abstract bool HasCellEventHandler();
        public abstract bool HasCellEventHandler(UnitState state);
        public abstract bool HasUnitEventHandler();
        public abstract bool HasUnitEventHandler(UnitState state);
        public abstract void IncrementAbilityPoints(int points = 1);
        public abstract bool IsFactoryReset();
        public abstract bool IsHacked();
        public abstract bool IsPlaced();
        public abstract bool IsUnderclocked();
        public abstract void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex);
        public abstract void OnCellEnter(TerrainGridSystem sender, int cellIndex);
        public abstract void OnCellExit(TerrainGridSystem sender, int cellIndex);
        public abstract void OnUnitClick(AbsUnit unit, int buttonIndex);
        public abstract void OnUnitEnter(AbsUnit unit);
        public abstract void OnUnitExit(AbsUnit unit);
        public abstract void PlaceOnCell(int cellIndex);
        public abstract void RecordPowerState();
        public abstract void RevertPowerState();
        public abstract void SetCell(int cellIndex);
        public abstract void TransferPowerFrom(IPowerContainerInteractable container, int power = 1);
        public abstract void TransferPowerTo(IPowerContainerInteractable container, int power = 1);
        public abstract void TransitionToState(UnitState state);
        public abstract void Underclock(int duration);

        public AbsAbility[] GetAbilities(bool filterShowInTray = true)
        {
            AbsAbility[] abilities = gameObject.GetComponents<AbsAbility>();

            if(!filterShowInTray)
                return abilities;

            List<AbsAbility> filteredAbilities = new List<AbsAbility>();

            foreach(AbsAbility ability in abilities)
            {
                if(ability.ShowInTray())
                    filteredAbilities.Add(ability);
            }

            return filteredAbilities.ToArray();
        }

        public T GetAbility<T>() where T : AbsAbility
        {
            return GetComponent<T>();
        }

        public AbsAbility[] GetCooldownAbilities()
        {
            AbsAbility[] abilities = gameObject.GetComponents<AbsAbility>();
            return abilities.Where(ability => ability is ICooldownManagerClient).ToArray();
        }

        public AbsAbility[] GetPoweredAbilities()
        {
            AbsAbility[] abilities = gameObject.GetComponents<AbsAbility>();
            return abilities.Where(ability => ability is IPowerManagerClient).ToArray();
        }

        public bool HasAbility<T>() where T : AbsAbility
        {
            return GetAbility<T>() != null;
        }

        public bool HasEnemyTag()
        {
            return HasTag(AllUnitsManager.ENEMY_TAG);
        }

        public bool HasPlayerTag()
        {
            return HasTag(AllUnitsManager.PLAYER_TAG);
        }

        public bool HasTag(string tag)
        {
            return gameObject.CompareTag(tag);
        }

        public bool IsEnemy()
        {
            return !IsPlayer();
        }

        public bool IsPlayer()
        {
            return HasPlayerTag() && !IsHacked() || HasEnemyTag() && IsHacked();
        }

        public bool SameTagAs(AbsUnit unit)
        {
            return HasTag(unit.gameObject.tag);
        }

        public bool SameTeamAs(AbsUnit unit)
        {
            return IsPlayer() && unit.IsPlayer() || IsEnemy() && unit.IsEnemy();
        }
    }
}