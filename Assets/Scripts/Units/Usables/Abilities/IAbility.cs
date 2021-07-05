using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    public interface IAbility : IUsable
    {
        AudioClip GetSoundEffect();
    }
}