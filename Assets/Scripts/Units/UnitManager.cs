using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units
{
    public class UnitManager : MonoBehaviour
    {
        private static UnitController[] _units;
        public static UnitController[] Units { get => _units; }

        private static UnitController _activeUnit;
        public static UnitController ActiveUnit { get => _activeUnit; }

        public const string PLAYER_TAG = "Player";
        public const string ENEMY_TAG = "Enemy";

        void Awake()
        {
            _units = FindObjectsOfType<UnitController>();
        }

        void OnDisable()
        {
            ActiveState.OnStateEnter -= SetActiveUnit;
        }

        void OnEnable()
        {
            ActiveState.OnStateEnter += SetActiveUnit;
        }

        void SetActiveUnit(UnitController unit)
        {
            _activeUnit = unit;
        }
    }
}