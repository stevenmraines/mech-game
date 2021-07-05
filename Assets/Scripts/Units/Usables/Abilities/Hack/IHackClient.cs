namespace RainesGames.Units.Usables.Abilities.Hack
{
    public interface IHackClient
    {
        int GetHackedTurnsRemaining();
        void Hack(int duration);
        bool IsHacked();
    }
}