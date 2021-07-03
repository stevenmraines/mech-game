using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Mechs/Classes/Mech Class Data", order = 1)]
public class DataMechClass : ScriptableObject
{
	[Range(5, 8)] public int BaseMovement = 6;
	public string ClassName = "";
}