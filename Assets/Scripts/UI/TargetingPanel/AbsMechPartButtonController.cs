using RainesGames.Units;
using RainesGames.Units.Mechs.MechParts;
using UnityEngine;
using UnityEngine.UI;

namespace RainesGames.UI.TargetingPanel
{
    public abstract class AbsMechPartButtonController : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        protected IUnit _activeUnit;
        protected IUnit _targetUnit;
        protected float _alphaThreshold = .2f;

        protected virtual void Awake()
        {
            _button.GetComponent<Image>().alphaHitTestMinimumThreshold = _alphaThreshold;
        }

        protected Color GetButtonColor(int hitPoints, int maxHitPoints)
        {
            float hitPointsPercentage = (float)hitPoints / maxHitPoints;
            float red = (1 - hitPointsPercentage) * 5;
            float green = 1f;

            if(hitPointsPercentage < 0.75)
            {
                red = 1f;
                green = hitPointsPercentage;
            }

            if(hitPoints == 0)
                red = 0;

            return new Color(red, green, 0, 1f);
        }

        public abstract void OnButtonClick();

        protected void SetButtonColorAndText(IMechPart mechPart)
        {
            int hitPoints = mechPart.GetHitPoints();
            int maxHitPoints = mechPart.GetMaxHitPoints();
            _button.GetComponent<Image>().color = GetButtonColor(hitPoints, maxHitPoints);

            string headButtonText = $"{hitPoints} / {maxHitPoints}";
            _button.gameObject.transform.Find("Text").GetComponent<Text>().text = headButtonText;
        }

        public virtual void SetUnits(IUnit activeUnit, IUnit targetUnit)
        {
            _activeUnit = activeUnit;
            _targetUnit = targetUnit;
        }
    }
}
