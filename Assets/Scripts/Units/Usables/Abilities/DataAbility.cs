using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Units/Ability/Data", order = 1)]
    public class DataAbility : ScriptableObject
    {
        [Range(0, 2)] public int FirstAbilityCost = 2;
        [Range(0, 2)] public int SecondAbilityCost = 1;
        public bool ShowInTray = true;
        public AudioClip SoundEffect;
        public UnitState State;
    }
}