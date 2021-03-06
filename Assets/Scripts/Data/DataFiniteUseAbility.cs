using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "FiniteUseData", menuName = "Scriptable Objects/Units/Usables/Ability/Finite Use Data", order = 4)]
    public class DataFiniteUseAbility : ScriptableObject
    {
        [Range(0, 2)] public int NumberOfUses = 2;
    }
}