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
    public interface IUnit : IActionPointsManagerClient, IFactoryResetClient, IHackClient,
        IPositionManagerClient, IPowerRerouteManagerClient, IUnderclockClient, IActiveUsableManagerClient
    {
        IList<IAbility> GetAbilities();
        IList<IAbility> GetCooldownAbilities();
        IList<IAbility> GetPoweredAbilities();
        IList<IUsable> GetTrayUsables();
        T GetUsable<T>() where T : IUsable;
        bool HasEnemyTag();
        bool HasPlayerTag();
        bool HasTag(string tag);
        bool HasUsable<T>() where T : IUsable;
        bool IsEnemy();
        bool IsPlayer();
        bool SameTagAs(IUnit unit);
        bool SameTeamAs(IUnit unit);
    }
}