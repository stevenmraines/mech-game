using UnityEngine;

namespace RainesGames.Selection
{
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}