using RainesGames.Grid;
using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Position;
using RainesGames.Units.Power;
using RainesGames.Units.States;

namespace RainesGames.Units
{
    public interface IUnit : IAbilityPointsManagerClient, ICellEvents, IFactoryResetClient, IHackClient,
        IPositionManagerClient, IPowerManagerClient, IUnderclockClient, IUnitEvents, IUnitStateManagerClient
    {
        T GetAbility<T>() where T : AbsAbility;
        AbsAbility[] GetAbilities(bool filterShowInTray = true);
        AbsAbility[] GetPoweredAbilities();
        bool HasAbility<T>() where T : AbsAbility;
        bool HasEnemyTag();
        bool HasPlayerTag();
        bool HasTag(string tag);
        bool IsEnemy();
        bool IsPlayer();
        bool SameTagAs(AbsUnit unit);
        bool SameTeamAs(AbsUnit unit);
    }
}