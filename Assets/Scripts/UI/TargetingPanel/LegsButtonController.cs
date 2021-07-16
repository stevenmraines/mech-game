using RainesGames.Units;
using RainesGames.Units.Mechs;
using RainesGames.Units.Mechs.MechParts;

namespace RainesGames.UI.TargetingPanel
{
    public class LegsButtonController : AbsMechPartButtonController
    {
        public delegate void ButtonClickDelegate(IUnit activeUnit, IUnit targetUnit, IMechPart mechPart);
        public static event ButtonClickDelegate OnButtonClickReroute;

        public override void OnButtonClick()
        {
            MechController targetMech = (MechController) _targetUnit;
            OnButtonClickReroute?.Invoke(_activeUnit, _targetUnit, targetMech.GetComponent<Legs>());
        }

        public override void SetUnits(IUnit activeUnit, IUnit targetUnit)
        {
            base.SetUnits(activeUnit, targetUnit);

            if(_targetUnit is MechController)
                SetButtonColorAndText(((MechController)_targetUnit).GetComponent<Legs>());
        }
    }
}
