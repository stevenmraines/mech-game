using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}