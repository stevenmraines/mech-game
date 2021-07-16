using RainesGames.UI.TargetingPanel;
using UnityEngine;
using UnityEngine.UI;

namespace RainesGames.UI
{
    public class HudUiController : MonoBehaviour
    {
        [SerializeField] private Text _battleStartMessage;
        [SerializeField] private Text _playerLostMessage;
        [SerializeField] private Text _playerWonMessage;
        [SerializeField] private TargetingPanelController _targetingPanel;

        public void DisableBattleStartMessage()
        {
            _battleStartMessage.gameObject.SetActive(false);
        }

        public void EnableBattleStartMessage()
        {
            _battleStartMessage.gameObject.SetActive(true);
        }
        
        public void DisablePlayerLostMessage()
        {
            _playerLostMessage.gameObject.SetActive(false);
        }

        public void EnablePlayerLostMessage()
        {
            _playerLostMessage.gameObject.SetActive(true);
        }

        public void DisablePlayerWonMessage()
        {
            _playerWonMessage.gameObject.SetActive(false);
        }

        public void EnablePlayerWonMessage()
        {
            _playerWonMessage.gameObject.SetActive(true);
        }

        public TargetingPanelController GetTargetingPanel()
        {
            return _targetingPanel;
        }
    }
}