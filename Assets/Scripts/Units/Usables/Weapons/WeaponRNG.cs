using RainesGames.Units.Mechs.MechParts;
using UnityEngine;

namespace RainesGames.Units.Usables.Weapons
{
    public class WeaponRNG
    {
        public static bool HitSuccessful(IUnit targetUnit, IMechPart mechPart, IWeapon weapon)
        {
            float accuracy = weapon.GetAccuracy();
            float test = Random.value;
            return accuracy >= test;
        }
    }
}
