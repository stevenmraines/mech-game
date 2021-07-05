using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class DotProductSelector : MonoBehaviour, ISelector
    {
        [SerializeField] private float _threshold = 0.99f;

        public IUnit MakeSelection(Ray ray, IList<IUnit> selectables)
        {
            IUnit selection = null;
            float closest = 0;

            foreach(IUnit unit in selectables)
            {
                Vector3 viewportDirection = ray.direction;
                Vector3 directionToSelectable = ((MonoBehaviour)unit).transform.position - ray.origin;
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