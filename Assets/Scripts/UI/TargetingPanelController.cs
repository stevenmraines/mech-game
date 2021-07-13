using RainesGames.Units;
using RainesGames.Units.Mechs;
using RainesGames.Units.Mechs.MechParts;
using UnityEngine;
using UnityEngine.UI;

namespace RainesGames.UI
{
    public class TargetingPanelController : MonoBehaviour
    {
        [SerializeField] private Button _headButton;
        [SerializeField] private Button _leftArmButton;
        [SerializeField] private Button _legsButton;
        [SerializeField] private Button _rightArmButton;
        [SerializeField] private Button _torsoButton;

        private IUnit _targetedUnit;

        void Awake()
        {
            //Hide();
        }

        Color GetButtonColor(int hitPoints, int maxHitPoints)
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

        void Hide()
        {
            gameObject.SetActive(false);
        }

        void SetButtonColorAndText(Button button, IMechPart mechPart)
        {
            int hitPoints = mechPart.GetHitPoints();
            int maxHitPoints = mechPart.GetMaxHitPoints();
            button.GetComponent<Image>().color = GetButtonColor(hitPoints, maxHitPoints);
            
            string headButtonText = $"{hitPoints} / {maxHitPoints}";
            button.gameObject.transform.Find("Text").GetComponent<Text>().text = headButtonText;
        }

        public void SetTargetedUnit(IUnit unit)
        {
            _targetedUnit = unit;

            if (_targetedUnit is MechController)
            {
                MechController targetedMech = (MechController) _targetedUnit;
                
                SetButtonColorAndText(_headButton, targetedMech.GetComponent<Head>());
                SetButtonColorAndText(_leftArmButton, targetedMech.GetComponent<LeftArm>());
                SetButtonColorAndText(_legsButton, targetedMech.GetComponent<Legs>());
                SetButtonColorAndText(_rightArmButton, targetedMech.GetComponent<RightArm>());
                SetButtonColorAndText(_torsoButton, targetedMech.GetComponent<Torso>());
            }

            Show();
        }

        void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
