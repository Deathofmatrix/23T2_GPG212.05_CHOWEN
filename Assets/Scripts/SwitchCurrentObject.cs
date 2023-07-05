using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    public class SwitchCurrentObject : MonoBehaviour
    {
        [SerializeField] private GameObject placeable;

        public delegate void ChoosePlaceableAction(GameObject placeableToSwitchTo);
        public static event ChoosePlaceableAction ChoosePlaceable;

        public void OnChoosePlaceable()
        {
            Debug.Log("onChoose placeable is being called");
            if (ChoosePlaceable != null)
            {
                Debug.Log("choose placeable isnt null");
                ChoosePlaceable(placeable);
            }
        }
    }
}
