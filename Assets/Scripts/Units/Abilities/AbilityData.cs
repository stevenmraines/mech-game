using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Units/Ability", order = 1)]
public class AbilityData : ScriptableObject
{
	public int MaxPower = 1;
	public int MinPower = 1;
}