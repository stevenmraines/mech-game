using UnityEngine;

[CreateAssetMenu(fileName = "UsableData", menuName = "Scriptable Objects/Units/Usables/Usable Data", order = 2)]
public class DataUsable : ScriptableObject
{
    public string UsableName = "";
    [Range(0, 2)] public int FirstActionCost = 1;
    [Range(0, 2)] public int SecondActionCost = 1;
    public bool ShowInTray = true;
    public bool NeedsLOS = true;
}