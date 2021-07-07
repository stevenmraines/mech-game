using UnityEngine;

[CreateAssetMenu(fileName = "ClassData", menuName = "Scriptable Objects/Units/Mechs/Classes/Class Data", order = 1)]
public class DataMechClass : ScriptableObject
{
	[Range(5, 8)] public int BaseMovement = 6;
	public string ClassName = "";
	[Range(6, 12)] public int MaxPower;
	[Range(1, 3)] public int StartOfTurnActionPoints = 2;
}