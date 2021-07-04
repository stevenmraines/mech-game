namespace RainesGames.Units.Usables.Abilities
{
    public interface IFiniteUseManagerClient
    {
        void DecrementUsesRemaining();
        int GetUsesRemaining();
        bool HasMoreUses();
        void SetUsesRemaining();
    }
}