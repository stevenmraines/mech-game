using UnityEngine;

[CreateAssetMenu(fileName = "WeightData", menuName = "Scriptable Objects/Units/Weight Data", order = 3)]
public class DataWeight : ScriptableObject
{
    [Range(0, 10)] public int Weight = 1;
}