using System;
using System.Collections.Generic;
using UnityEngine;

public class DotProductSelector : MonoBehaviour, ISelector
{
    [SerializeField] private float _threshold = 0.99f;

    public GameObject MakeSelection(Ray ray, List<GameObject> selectables)
    {
        GameObject selection = null;
        float closest = 0;

        for(int i = 0; i < selectables.Count; i++)
        {
            Vector3 viewportDirection = ray.direction;
            Vector3 directionToSelectable = selectables[i].transform.position - ray.origin;
            float lookPercentage = Vector3.Dot(viewportDirection.normalized, directionToSelectable.normalized);

            if(lookPercentage > _threshold && lookPercentage > closest)
            {
                closest = lookPercentage;
                selection = selectables[i];
            }
        }

        return selection;
    }
}
