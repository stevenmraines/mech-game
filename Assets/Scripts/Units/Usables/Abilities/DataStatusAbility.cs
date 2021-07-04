using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Units/Ability/Status Ability Data", order = 5)]
    public class DataStatusAbility : ScriptableObject
    {
        [Range(1, 4)] public int Duration;
    }
}