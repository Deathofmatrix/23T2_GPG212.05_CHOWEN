using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelDesignSim
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _origin;
        private Vector3 _difference;

        private Camera _mainCamera;

        private bool _isDragging;

        [SerializeField] private BoxCollider2D boundsBox;

        private Vector3 _minBounds;
        private Vector3 _maxBounds;

        private float _halfHeight;
        private float _halfWidth;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _minBounds = boundsBox.bounds.min;
            _maxBounds = boundsBox.bounds.max;

            _halfHeight = _mainCamera.orthographicSize;
            _halfWidth = _halfHeight * Screen.width / Screen.height;
        }

        private void Update()
        {
            if (_isDragging) return;
            float clampedX = Mathf.Clamp(transform.position.x, _minBounds.x + + _halfWidth, _maxBounds.x - _halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, _minBounds.y + _halfHeight, _maxBounds.y - _halfHeight);
            transform.position =  new Vector3(clampedX, clampedY, transform.position.z);
        }

        public void SetBounds(BoxCollider2D newBounds)
        {
            boundsBox = newBounds;

            _minBounds = boundsBox.bounds.min;
            _maxBounds = boundsBox.bounds.max;
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
