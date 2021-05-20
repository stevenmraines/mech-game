public interface ICombatState
{
    void OnCellClick(int cellIndex, int buttonIndex);
    void OnUnitClick(UnitController unit, int buttonIndex);
    void OnUnitMouseEnter(UnitController unit);
    void OnUnitMouseExit(UnitController unit);
}
