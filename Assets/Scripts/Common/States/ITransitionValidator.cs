namespace RainesGames.Common.States
{
    public interface ITransitionValidator
    {
        bool IsValid(IState state);
    }
}