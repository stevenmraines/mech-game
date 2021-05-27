using UnityEngine;

namespace RainesGames.Units.Selection
{
    // TODO make all this selection stuff specific to units or figure out how to handle any gameobject
    public class UnitSelectionManager : MonoBehaviour
    {
        private static IRayProvider _rayProvider;
        private static ISelectablesProvider _selectablesProvider;
        private static ISelector _selector;
        private static ISelectionResponse _selectionResponse;

        private static GameObject _currentSelection;
        public static GameObject CurrentSelection => _currentSelection;

        private static GameObject _oldSelection;
        private static bool _differentSelection => _oldSelection != _currentSelection;
        private static bool _mouseEnter => _currentSelection != null && _differentSelection;
        private static bool _mouseExit => _currentSelection == null && _oldSelection != null;

        public static Outline.Mode OutlineMode;
        public static float OutlineWidth;
        public static Color PlayerColor;
        public static Color EnemyColor;

        public delegate void UnitClickDelegate(UnitController unit, int buttonIndex);
        public static event UnitClickDelegate OnUnitClick;

        public delegate void UnitDelegate(UnitController unit);
        public static event UnitDelegate OnUnitMouseEnter;
        public static event UnitDelegate OnUnitMouseExit;

        void Awake()
        {
            _rayProvider = GetComponent<IRayProvider>();
            _selectablesProvider = GetComponent<ISelectablesProvider>();
            _selector = GetComponent<ISelector>();
            _selectionResponse = GetComponent<ISelectionResponse>();

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

        static void TriggerMouseEvents()
        {
            if(_mouseEnter)
                OnUnitMouseEnter?.Invoke(_currentSelection.GetComponent<UnitController>());

            if(_mouseExit)
                OnUnitMouseExit?.Invoke(_oldSelection.GetComponent<UnitController>());

            // TODO use new input system
            if(_currentSelection != null && Input.GetMouseButtonUp(0))
                OnUnitClick?.Invoke(_currentSelection.GetComponent<UnitController>(), 0);
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