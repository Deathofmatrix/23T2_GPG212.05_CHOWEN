using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelDesignSim
{
    public class CameraDrag : MonoBehaviour
    {
        private Vector3 _origin;
        private Vector3 _difference;

        private Camera _mainCamera;

        private bool _isDragging;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void OnDrag(InputAction.CallbackContext ctx)
        {
            if (ctx.started) _origin = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _isDragging = ctx.started || ctx.performed;
        }

        private void LateUpdate()
        {
            if (!_isDragging) return;

            _difference = GetMousePosition - transform.position;
            transform.position = _origin - _difference;
        }

        private Vector3 GetMousePosition => _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
