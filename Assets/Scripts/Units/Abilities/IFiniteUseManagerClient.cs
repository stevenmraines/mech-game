namespace RainesGames.Units.Abilities
{
    public interface IFiniteUseManagerClient
    {
        void DecrementUsesRemaining();
        int GetUsesRemaining();
        bool HasMoreUses();
        void SetUsesRemaining();
    }
}