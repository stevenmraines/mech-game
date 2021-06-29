﻿using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class DotProductSelector : MonoBehaviour, ISelector
    {
        [SerializeField] private float _threshold = 0.99f;

        public AbsUnit MakeSelection(Ray ray, List<AbsUnit> selectables)
        {
            AbsUnit selection = null;
            float closest = 0;

            foreach(AbsUnit unit in selectables)
            {
                Vector3 viewportDirection = ray.direction;
                Vector3 directionToSelectable = unit.transform.position - ray.origin;
                float lookPercentage = Vector3.Dot(viewportDirection.normalized, directionToSelectable.normalized);

                if(lookPercentage > _threshold && lookPercentage > closest)
                {
                    closest = lookPercentage;
                    selection = unit;
                }
            }

            return selection;
        }
    }
}