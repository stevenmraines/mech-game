using RainesGames.Units.Usables.Weapons;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Units/Usables/Weapons/Weapon Data", order = 1)]
public class DataWeapon : ScriptableObject
{
    public MountType MountType = MountType.SINGLE_HANDED;
    [Range(0.3f, 1f)] public float Accuracy = 1.0f;
}