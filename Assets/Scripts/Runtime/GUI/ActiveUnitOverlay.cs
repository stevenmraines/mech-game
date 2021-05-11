using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUnitOverlay : MonoBehaviour
{
    private ISelectablesProvider _selectablesProvider;
    private UnitSelectionManager _usm;

    void Awake()
    {
        _selectablesProvider = GetComponent<ISelectablesProvider>();
        _usm = FindObjectOfType<UnitSelectionManager>();
    }

    void OnGUI()
    {
        GameObject currentSelection = _usm.GetCurrentSelection();

        List<GameObject> selectables = _selectablesProvider.GetSelectables();

        for(int i = 0; i < selectables.Count; i++)
        {
            string unitString = selectables[i].name;

            if(_usm.GetCurrentSelection() == selectables[i])
                unitString += " - HOVERED";

            UnitStateController stateController = selectables[i].GetComponent<UnitStateController>();

            if(stateController.currentState == stateController.activeState)
                unitString += " - ACTIVE";

            GUI.Label(new Rect(10, i * 20 + 10, 300, 20), unitString);
        }
    }
}
