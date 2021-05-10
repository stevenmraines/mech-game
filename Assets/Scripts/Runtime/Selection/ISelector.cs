using System.Collections.Generic;
using UnityEngine;

public interface ISelector
{
    GameObject MakeSelection(Ray ray, List<GameObject> selectables);
}
