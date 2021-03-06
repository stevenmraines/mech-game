using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "PowerData", menuName = "Scriptable Objects/Units/Usables/Ability/Power Data", order = 3)]
    public class DataPoweredAbility : ScriptableObject
    {
        [Range(1, 3)] public int MaxPower = 1;
        [Range(1, 3)] public int MinPower = 1;
    }
}