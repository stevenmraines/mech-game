using System.Collections.Generic;
using UnityEngine;
using TGS;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelectablesProvider _selectablesProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private TerrainGridSystem _terrainGridSystem;

    private GameObject _currentSelection;
    private GameObject _oldSelection;
    private bool _differentSelection => _oldSelection != _currentSelection;

    public static Outline.Mode _outlineMode;
    public static float _outlineWidth;
    public static Color _playerColor;
    public static Color _enemyColor;

    void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selectablesProvider = GetComponent<ISelectablesProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();

        _terrainGridSystem = FindObjectOfType<TerrainGridSystem>();

        _outlineMode = Outline.Mode.OutlineAll;
        _outlineWidth = 7f;
        _playerColor = Color.green;
        _enemyColor = Color.red;
    }

    private void DoSelectAndDeselect()
    {
        if(!_differentSelection)
            return;

        if(_oldSelection != null)
            _selectionResponse.OnDeselect(_oldSelection);

        if(_currentSelection != null)
            _selectionResponse.OnSelect(_currentSelection);
    }

    public GameObject GetCurrentSelection()
    {
        return _currentSelection;
    }

    private void HandleCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
    {
        if (buttonIndex != 0 || _currentSelection != null)
            return;

        sender.CellGetGameObject(cellIndex).GetComponent<CellStateController>().HandleCellClick();
    }

    private void HandleUnitClick()
    {
        if(_currentSelection == null)
            return;

        UnitStateController stateController = _currentSelection.GetComponent<UnitStateController>();
        stateController.TransitionToState(stateController.activeState);
    }

    void OnDisable()
    {
        _terrainGridSystem.OnCellClick -= HandleCellClick;
    }

    void OnEnable()
    {
        _terrainGridSystem.OnCellClick += HandleCellClick;
    }

    void Update()
    {
        _oldSelection = _currentSelection;

        _currentSelection = _selector.MakeSelection(
            _rayProvider.CreateRay(),
            _selectablesProvider.GetSelectables()
        );

        DoSelectAndDeselect();

        // TODO use new input system
        if(Input.GetMouseButtonUp(0))
            HandleUnitClick();
    }
}
