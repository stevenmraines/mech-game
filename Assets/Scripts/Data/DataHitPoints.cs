using UnityEngine;

[CreateAssetMenu(fileName = "HitPointsData", menuName = "Scriptable Objects/Units/Hit Points Data", order = 2)]
public class DataHitPoints : ScriptableObject
{
    [Range(1, 10)] public int MaxHitPoints = 5;
}