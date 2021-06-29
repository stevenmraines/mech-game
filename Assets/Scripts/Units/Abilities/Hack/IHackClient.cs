namespace RainesGames.Units.Abilities.Hack
{
    public interface IHackClient
    {
        int GetHackedTurnsRemaining();
        void Hack();
        bool IsHacked();
    }
}