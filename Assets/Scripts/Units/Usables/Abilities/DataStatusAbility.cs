using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "AbilityData", menuName = "Scriptable Objects/Units/Ability/Status Ability AbilityData", order = 5)]
    public class DataStatusAbility : ScriptableObject
    {
        [Range(1, 4)] public int Duration;
    }
}