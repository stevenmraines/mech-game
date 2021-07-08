using UnityEngine;

[CreateAssetMenu(fileName = "UsableData", menuName = "Scriptable Objects/Units/Usables/Usable Data", order = 2)]
public class DataUsable : ScriptableObject
{
    [Range(0, 2)] public int FirstActionCost = 1;
    public bool NeedsLOS = true;
    [Range(0, 2)] public int SecondActionCost = 1;
    public bool ShowInTray = true;
    public string UsableName = "";
}