using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace LevelDesignSim
{
    public class PlacementSystem : MonoBehaviour
    {
        private Grid _grid;
        private GameObject _currentPlaceable;

        [SerializeField] private GameObject selectedPlaceable;
        private bool _isDragging = false;
        [SerializeField] private bool _isPointerOverUI;

        private void OnEnable()
        {
            SwitchCurrentObject.ChoosePlaceable += UpdatePlaceable;
        }

        private void OnDisable()
        {
            SwitchCurrentObject.ChoosePlaceable -= UpdatePlaceable;
        }

        private void UpdatePlaceable(GameObject placeableToSwitchTo)
        {
            Debug.Log("Update Placeable being called");
            selectedPlaceable = placeableToSwitchTo;
        }

        private void Start()
        {
            _grid = GetComponent<Grid>();
        }

        private void Update()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    _currentPlaceable = Instantiate(selectedPlaceable);
            //}

            //if (Input.GetMouseButton(0))
            //{
            //    Vector3 pos = _grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + _grid.cellSize / 2;
            //    _currentPlaceable.transform.position = pos;
            //}

            if (_isDragging)
            {
                Vector3 pos = _grid.WorldToCell(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())) + _grid.cellSize / 2;
                _currentPlaceable.transform.position = pos;
            }

            _isPointerOverUI = EventSystem.current.IsPointerOverGameObject();
        }

        public void OnClick(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                if (!_isPointerOverUI)
                {
                    _currentPlaceable = Instantiate(selectedPlaceable);
                    _isDragging = ctx.started || ctx.performed;
                }
            }

            if (ctx.canceled) { _isDragging = false; }
        }
    }
}
