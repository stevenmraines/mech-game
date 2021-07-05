using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Scriptable Objects/Mechs/Classes/Mech Class AbilityData", order = 1)]
public class DataMechClass : ScriptableObject
{
	[Range(5, 8)] public int BaseMovement = 6;
	public string ClassName = "";
	[Range(6, 12)] public int MaxPower;
	[Range(1, 3)] public int StartOfTurnActionPoints = 2;
}