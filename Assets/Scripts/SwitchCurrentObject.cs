using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelDesignSim
{
    public class SwitchCurrentObject : MonoBehaviour
    {
        [SerializeField] private GameObject placeable;

        public delegate void ChoosePlaceableAction(GameObject placeableToSwitchTo, SwitchCurrentObject buttonScript);
        public static event ChoosePlaceableAction ChoosePlaceable;

        public int numberOfObjectsToPlace;
        [SerializeField] private TextMeshProUGUI numberOfPlaceablesText;

        [SerializeField] private Image image;

        private void Start()
        {
            numberOfPlaceablesText = GetComponentInChildren<TextMeshProUGUI>();
            image = GetComponent<Image>();
        }

        public void OnChoosePlaceable()
        {
            //Debug.Log("onChoose placeable is being called");
            if (ChoosePlaceable != null)
            {
                //Debug.Log("choose placeable isnt null");
                ChoosePlaceable(placeable, this);
            }
        }

        private void Update()
        {
            numberOfPlaceablesText.text = $"x{numberOfObjectsToPlace}";
            if (numberOfObjectsToPlace <= 0)
            {
                image.color = new Color(0.5f, 0.5f, 0.5f, image.color.a);
            }
        }
    }
}
