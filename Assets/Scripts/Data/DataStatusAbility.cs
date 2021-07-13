using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "StatusData", menuName = "Scriptable Objects/Units/Usables/Ability/Status Data", order = 5)]
    public class DataStatusAbility : ScriptableObject
    {
        [Range(1, 4)] public int Duration;
    }
}