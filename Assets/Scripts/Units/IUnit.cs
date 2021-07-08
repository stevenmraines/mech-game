using RainesGames.Grid;
using RainesGames.Units.Position;
using RainesGames.Units.Power;
using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.FactoryReset;
using RainesGames.Units.Usables.Abilities.Hack;
using RainesGames.Units.Usables.Abilities.Underclock;
using System.Collections.Generic;
using RainesGames.Units.Usables;

namespace RainesGames.Units
{
    public interface IUnit : IActionPointsManagerClient, ICellEvents, IFactoryResetClient, IHackClient,
        IPositionManagerClient, IPowerRerouteManagerClient, IUnderclockClient, IUnitEvents, IActiveUsableManagerClient
    {
        T GetAbility<T>() where T : IAbility;
        IList<IAbility> GetAbilities(bool filterShowInTray = true);
        IList<IAbility> GetCooldownAbilities();
        IList<IAbility> GetPoweredAbilities();
        IList<IUsable> GetUsables(bool filterShowInTray = true);
        bool HasAbility<T>() where T : IAbility;
        bool HasEnemyTag();
        bool HasPlayerTag();
        bool HasTag(string tag);
        bool IsEnemy();
        bool IsPlayer();
        bool SameTagAs(IUnit unit);
        bool SameTeamAs(IUnit unit);
    }
}