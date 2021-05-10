using System.Collections.Generic;
using UnityEngine;

public interface ISelectablesProvider
{
    List<GameObject> GetSelectables();
}