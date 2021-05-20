using UnityEngine;
using UnityEngine.UI;

namespace RainesGames.UI
{
    public class HudUiController : MonoBehaviour
    {
        [SerializeField] private Text _battleStartMessage;

        public void DisableBattleStartMessage()
        {
            _battleStartMessage.gameObject.SetActive(false);
        }

        public void EnableBattleStartMessage()
        {
            _battleStartMessage.gameObject.SetActive(true);
        }
    }
}