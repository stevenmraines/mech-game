using UnityEngine;

namespace RainesGames.Units.Mechs.MechParts
{
    [CreateAssetMenu(fileName = "LegsData", menuName = "Scriptable Objects/Units/Mechs/Mech Parts/Legs/Legs Data", order = 1)]
    public class DataLegs : ScriptableObject
    {
        [Range(5, 10)] public int MaxWeight = 7;
    }
}