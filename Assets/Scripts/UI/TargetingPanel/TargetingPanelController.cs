using RainesGames.Units;
using UnityEngine;

namespace RainesGames.UI.TargetingPanel
{
    public class TargetingPanelController : MonoBehaviour
    {
        [SerializeField] private HeadButtonController _headButton;
        [SerializeField] private LeftArmButtonController _leftArmButton;
        [SerializeField] private LegsButtonController _legsButton;
        [SerializeField] private RightArmButtonController _rightArmButton;
        [SerializeField] private TorsoButtonController _torsoButton;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetUnits(IUnit activeUnit, IUnit targetUnit)
        {
            _headButton.SetUnits(activeUnit, targetUnit);
            _leftArmButton.SetUnits(activeUnit, targetUnit);
            _legsButton.SetUnits(activeUnit, targetUnit);
            _rightArmButton.SetUnits(activeUnit, targetUnit);
            _torsoButton.SetUnits(activeUnit, targetUnit);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
