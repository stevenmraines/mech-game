using RainesGames.Common.Power;
using RainesGames.Units.Position;
using RainesGames.Units.Power;
using System.Collections.Generic;
using System.Linq;
using RainesGames.Units.Usables;
using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.FactoryReset;
using RainesGames.Units.Usables.Abilities.Hack;
using RainesGames.Units.Usables.Abilities.Underclock;
using TGS;
using UnityEngine;

namespace RainesGames.Units
{
    public abstract class AbsUnit : MonoBehaviour, IUnit
    {
        protected ActionPointsManager _actionPointsManager;
        protected ActiveUsableManager _activeUsableManager;
        protected FactoryResetStatusManager _factoryResetStatusManager;
        protected HackStatusManager _hackStatusManager;
        protected PositionManager _positionManager;
        protected PowerRerouteManager _powerManager;
        protected UnderclockStatusManager _underclockStatusManager;

        protected virtual void Awake()
        {
            _actionPointsManager = new ActionPointsManager();
            _activeUsableManager = new ActiveUsableManager();
            _factoryResetStatusManager = new FactoryResetStatusManager();
            _hackStatusManager = new HackStatusManager();
            _positionManager = new PositionManager();
            _powerManager = new PowerRerouteManager();
            _underclockStatusManager = new UnderclockStatusManager();
        }

        public abstract void ClearActiveUsable();
        public abstract void DecrementActionPoints(int points = 1);
        public abstract void DiscardPowerState();
        public abstract void FactoryReset(int duration);
        public abstract bool FirstActionSpent();
        public abstract void ForceSpendAllActionPoints();
        public abstract int GetActionPoints();
        public abstract IUsable GetActiveUsable();
        public abstract int GetFactoryResetTurnsRemaining();
        public abstract int GetHackedTurnsRemaining();
        public abstract int GetMaxPower();
        public abstract int GetMovement();
        public abstract Cell GetPosition();
        public abstract int GetPower();
        public abstract int GetStartOfTurnActionPoints();
        public abstract IList<IUsable> GetTrayUsables();
        public abstract int GetUnderclockedTurnsRemaining();
        public abstract void Hack(int duration);
        public abstract void IncrementActionPoints(int points = 1);
        public abstract bool IsFactoryReset();
        public abstract bool IsHacked();
        public abstract bool IsPlaced();
        public abstract bool IsUnderclocked();
        public abstract void PlaceOnCell(int cellIndex);
        public abstract void RecordPowerState();
        public abstract void RevertPowerState();
        public abstract void SetActiveUsable(IUsable usable);
        public abstract void SetFallbackUsable();
        public abstract void SetCell(int cellIndex);
        public abstract void TransferPowerFrom(IPowerContainerInteractable container, int power = 1);
        public abstract void TransferPowerTo(IPowerContainerInteractable container, int power = 1);
        public abstract void Underclock(int duration);

        protected IList<IUsable> FilterNonTrayUsables(IList<IUsable> usables)
        {
            for(int i = usables.Count - 1; i >= 0; i--)
            {
                if(!usables[i].ShowInTray())
                    usables.RemoveAt(i);
            }

            return usables;
        }

        public IList<IAbility> GetAbilities()
        {
            return gameObject.GetComponents<IAbility>();
        }

        public IList<IAbility> GetCooldownAbilities()
        {
            IList<IAbility> abilities = gameObject.GetComponents<IAbility>();
            return abilities.Where(ability => ability is ICooldownManagerClient).ToArray();
        }

        public IList<IAbility> GetPoweredAbilities()
        {
            IList<IAbility> abilities = gameObject.GetComponents<IAbility>();
            return abilities.Where(ability => ability is IPowerManagerClient).ToArray();
        }

        public T GetUsable<T>() where T : IUsable
        {
            return GetComponent<T>();
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

        public bool HasUsable<T>() where T : IUsable
        {
            return GetUsable<T>() != null;
        }

        public bool IsEnemy()
        {
            return !IsPlayer();
        }

        public bool IsPlayer()
        {
            return HasPlayerTag() && !IsHacked() || HasEnemyTag() && IsHacked();
        }

        public bool SameTagAs(IUnit unit)
        {
            return HasTag(((MonoBehaviour)unit).gameObject.tag);
        }

        public bool SameTeamAs(IUnit unit)
        {
            return IsPlayer() && unit.IsPlayer() || IsEnemy() && unit.IsEnemy();
        }
    }
}