using System.Collections.Generic;

namespace RainesGames.Units.Abilities.Move.Path
{
    public interface IPathConfirmationResponse
    {
        void OnConfirm(List<int> path);
    }
}