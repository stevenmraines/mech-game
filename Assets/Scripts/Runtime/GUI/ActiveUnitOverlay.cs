using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUnitOverlay : MonoBehaviour
{
    private ISelectablesProvider _selectablesProvider;
    private SelectionManager _selectionManager;

    void Awake()
    {
        _selectablesProvider = GetComponent<ISelectablesProvider>();
        _selectionManager = FindObjectOfType<SelectionManager>();
    }

    void OnGUI()
    {
        GameObject currentSelection = _selectionManager.GetCurrentSelection();

        List<GameObject> selectables = _selectablesProvider.GetSelectables();

        for(int i = 0; i < selectables.Count; i++)
        {
            string unitString = selectables[i].name;

            if(_selectionManager.GetCurrentSelection() == selectables[i])
                unitString += " - HOVERED";

            UnitStateController stateController = selectables[i].GetComponent<UnitStateController>();

            if(stateController.currentState == stateController.activeState)
                unitString += " - ACTIVE";

            GUI.Label(new Rect(10, i * 20 + 10, 300, 20), unitString);
        }
    }
}
