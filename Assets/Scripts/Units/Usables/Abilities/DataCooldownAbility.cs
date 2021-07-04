using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [CreateAssetMenu(fileName = "CooldownData", menuName = "Scriptable Objects/Units/Ability/Cooldown Data", order = 2)]
    public class DataCooldownAbility : ScriptableObject
    {
        [Range(0, 4)] public int CooldownDuration = 0;
    }
}