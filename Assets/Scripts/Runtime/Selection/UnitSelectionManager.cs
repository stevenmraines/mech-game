using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelectablesProvider _selectablesProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private GameObject _currentSelection;

    public static Outline.Mode _outlineMode;
    public static float _outlineWidth;
    public static Color _playerColor;
    public static Color _enemyColor;

    private void Awake()
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

    private void Update()
    {
        GameObject oldSelection = _currentSelection;

        _currentSelection = _selector.MakeSelection(
            _rayProvider.CreateRay(),
            _selectablesProvider.GetSelectables()
        );

        if(oldSelection == _currentSelection)
            return;

        if(oldSelection != null)
            _selectionResponse.OnDeselect(oldSelection);

        if(_currentSelection != null)
            _selectionResponse.OnSelect(_currentSelection);
    }
}
