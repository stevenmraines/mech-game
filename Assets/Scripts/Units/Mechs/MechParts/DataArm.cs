using UnityEngine;

namespace RainesGames.Units.Mechs.MechParts
{
    [CreateAssetMenu(fileName = "ArmData", menuName = "Scriptable Objects/Units/Mechs/Mech Parts/Arm/Arm Data", order = 1)]
    public class DataArm : ScriptableObject
    {
        public bool HasShoulderMount = false;
    }
}