using RainesGames.Grid;
using RainesGames.Units;
using TGS;
using UnityEngine;

namespace RainesGames.Selection
{
    // TODO make all this selection stuff specific to units or figure out how to handle any gameobject
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider _rayProvider;
        private ISelectablesProvider _selectablesProvider;
        private ISelector _selector;
        private ISelectionResponse _selectionResponse;

        public GameObject CurrentSelection { get => _currentSelection; }
        private GameObject _currentSelection;
        private GameObject _oldSelection;
        private bool _differentSelection => _oldSelection != _currentSelection;
        private bool _mouseEnter => _currentSelection != null && _differentSelection;
        private bool _mouseExit => _currentSelection == null && _oldSelection != null;

        public static Outline.Mode OutlineMode;
        public static float OutlineWidth;
        public static Color PlayerColor;
        public static Color EnemyColor;

        public delegate void CellClickDelegate(int cellIndex, int buttonIndex);
        public static event CellClickDelegate OnCellClick;

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

        void CheckCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            /*
             * TGS.OnCellClick is fired even if some object sitting on top of a cell is clicked,
             * so catch it here first to make sure no units are selected. If not, then proceed.
             */
            if(buttonIndex != 0 || _currentSelection != null)
                return;

            OnCellClick?.Invoke(cellIndex, buttonIndex);
        }

        void CheckUnitClick()
        {
            if(_currentSelection == null)
                return;

            OnUnitClick?.Invoke(_currentSelection.GetComponent<UnitController>(), 0);
        }

        void DoSelectAndDeselect()
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
            Combat.States.PlayerPlacement.PlayerPlacementState.OnStateUpdate -= UpdateSelection;
            GridManager.TerrainGridSystem.OnCellClick -= CheckCellClick;
        }

        void OnEnable()
        {
            Combat.States.PlayerPlacement.PlayerPlacementState.OnStateUpdate += UpdateSelection;
            GridManager.TerrainGridSystem.OnCellClick += CheckCellClick;
        }

        void TriggerUnitMouseEvents()
        {
            // TODO Implement null checks when triggering other events like this
            if(_mouseEnter)
                OnUnitMouseEnter?.Invoke(_currentSelection.GetComponent<UnitController>());

            if(_mouseExit)
                OnUnitMouseExit?.Invoke(_oldSelection.GetComponent<UnitController>());
        }

        void UpdateSelection()
        {
            _oldSelection = _currentSelection;

            _currentSelection = _selector.MakeSelection(
                _rayProvider.CreateRay(),
                _selectablesProvider.GetSelectables()
            );

            DoSelectAndDeselect();
            TriggerUnitMouseEvents();

            // TODO use new input system
            if(Input.GetMouseButtonUp(0))
                CheckUnitClick();
        }
    }
}