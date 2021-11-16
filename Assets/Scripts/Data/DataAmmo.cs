using UnityEngine;

[CreateAssetMenu(fileName = "AmmoData", menuName = "Scriptable Objects/Units/Usables/Weapons/Ammo Data", order = 1)]
public class DataAmmo : ScriptableObject
{
	[Range(-1, 3)] public int NumberOfClips = 0;  // -1 = Infinite reloads
	[Range(1, 5)] public int ShotsPerClip = 3;
}