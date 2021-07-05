using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    [RequireComponent(typeof(IRayProvider))]
    [RequireComponent(typeof(ISelectablesProvider))]
    [RequireComponent(typeof(ISelectionResponse))]
    [RequireComponent(typeof(ISelector))]
    public class UnitSelectionManager : MonoBehaviour
    {
        private static IRayProvider _rayProvider;
        private static ISelectablesProvider _selectablesProvider;
        private static ISelectionResponse _selectionResponse;
        private static ISelector _selector;

        private static IUnit _activeUnit;
        public static IUnit ActiveUnit => _activeUnit;

        private static IUnit _currentSelection;
        public static IUnit CurrentSelection => _currentSelection;

        private static IUnit _oldSelection;
        private static bool _differentSelection => _oldSelection != _currentSelection;
        private static bool _mouseEnter => _currentSelection != null && _differentSelection;
        private static bool _mouseExit => _currentSelection == null && _oldSelection != null;

        public static Outline.Mode OutlineMode;
        public static float OutlineWidth;
        public static Color PlayerColor;
        public static Color EnemyColor;

        public delegate void UnitClickDelegate(IUnit unit, int buttonIndex);
        public static event UnitClickDelegate OnUnitClick;

        public delegate void UnitTransitDelegate(IUnit unit);
        public static event UnitTransitDelegate OnUnitEnter;
        public static event UnitTransitDelegate OnUnitExit;

        void Awake()
        {
            _rayProvider = GetComponent<IRayProvider>();
            _selectablesProvider = GetComponent<ISelectablesProvider>();
            _selectionResponse = GetComponent<ISelectionResponse>();
            _selector = GetComponent<ISelector>();

            OutlineMode = Outline.Mode.OutlineAll;
            OutlineWidth = 7f;
            PlayerColor = Color.green;
            EnemyColor = Color.red;
        }

        static void DoSelectionResponse()
        {
            if(!_differentSelection)
                return;

            if(_oldSelection != null)
                _selectionResponse.OnDeselect(_oldSelection);

            if(_currentSelection != null)
                _selectionResponse.OnSelect(_currentSelection);
        }

        void OnDisable()
        {
            EnemyTurnState.OnExitState -= ResetActiveUnit;
            EnemyPlacementState.OnExitState -= ResetActiveUnit;
            PlayerPlacementState.OnExitState -= ResetActiveUnit;
            PlayerTurnState.OnExitState -= ResetActiveUnit;
        }

        void OnEnable()
        {
            EnemyTurnState.OnExitState += ResetActiveUnit;
            EnemyPlacementState.OnExitState += ResetActiveUnit;
            PlayerPlacementState.OnExitState += ResetActiveUnit;
            PlayerTurnState.OnExitState += ResetActiveUnit;
        }

        void ResetActiveUnit()
        {
            SetActiveUnit(null);
        }

        public static void SetActiveUnit(IUnit unit)
        {
            _activeUnit = unit;
        }

        static void TriggerMouseEvents()
        {
            if(_mouseEnter)
                OnUnitEnter?.Invoke(_currentSelection);

            if(_mouseExit)
                OnUnitExit?.Invoke(_oldSelection);

            // TODO use new input system
            if(_currentSelection != null && Input.GetMouseButtonUp(0))
                OnUnitClick?.Invoke(_currentSelection, 0);
        }

        public static void UpdateSelection()
        {
            _oldSelection = _currentSelection;

            _currentSelection = _selector.MakeSelection(
                _rayProvider.CreateRay(),
                _selectablesProvider.GetSelectables()
            );

            DoSelectionResponse();

            TriggerMouseEvents();
        }
    }
}