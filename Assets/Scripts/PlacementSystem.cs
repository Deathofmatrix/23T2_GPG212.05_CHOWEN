using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelDesignSim
{
    public class PlacementSystem : MonoBehaviour
    {
        private Grid _grid;
        private GameObject _currentPlaceable;

        [SerializeField] private GameObject selectedPlaceable;
        private void Start()
        {
            _grid = GetComponent<Grid>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentPlaceable = Instantiate(selectedPlaceable);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 pos = _grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + _grid.cellSize / 2;
                _currentPlaceable.transform.position = pos;
            }
        }
    }
}
