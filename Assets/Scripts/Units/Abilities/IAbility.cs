using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    public interface IAbility
    {
        bool CanBeUsed();
        int GetAbilityCost();
        int GetFirstAbilityCost();
        int GetSecondAbilityCost();
        AudioClip GetSoundEffect();
        UnitState GetState();
        bool IsAffordable();
        bool ShowInTray();
    }
}