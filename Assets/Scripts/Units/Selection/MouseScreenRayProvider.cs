﻿using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField] private UnityEngine.Camera _mainCamera;

        public Ray CreateRay()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}