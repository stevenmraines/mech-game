using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelectablesProvider _selectablesProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

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

    private void HandleUnitClick()
    {
        if(_currentSelection == null)
            return;

        UnitStateController stateController = _currentSelection.GetComponent<UnitStateController>();
        stateController.TransitionToState(stateController.activeState);
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
