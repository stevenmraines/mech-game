using UnityEngine;

[CreateAssetMenu(fileName = "RangeData", menuName = "Scriptable Objects/Units/Usables/Range Data", order = 3)]
public class DataRange : ScriptableObject
{
    [Range(1, 30)] public int MaxRange = 1;
    [Range(1, 30)] public int MinRange = 1;
    public bool NeedsLOS = true;
}