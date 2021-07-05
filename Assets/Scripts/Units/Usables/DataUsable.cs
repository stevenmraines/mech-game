using RainesGames.Units.States;
using UnityEngine;

[CreateAssetMenu(fileName = "UsableData", menuName = "Scriptable Objects/Units/Usable/Usable AbilityData", order = 1)]
public class DataUsable : ScriptableObject
{
    [Range(0, 2)] public int FirstActionCost = 1;
    public bool NeedsLOS = true;
    [Range(0, 2)] public int SecondActionCost = 1;
    public bool ShowInTray = true;
    public UnitState State;
    public string UsableName = "";
}