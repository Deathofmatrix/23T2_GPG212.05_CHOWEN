using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelDesignSim
{
    public class MatchButtonColour : MonoBehaviour
    {
        [SerializeField] private Image parentImage;
        private Image image;
        private Color pressedColour = new Color32(200, 200, 200, 255);

        private bool _isBeingClicked = false;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            if (_isBeingClicked) return;
            Color newColour = new Color(parentImage.color.r, parentImage.color.g, parentImage.color.b);
            image.color = newColour;
        }

        public void ChangeChildColour()
        {
            StartCoroutine(ChangeColorOfButtonChildren());
        }

        private IEnumerator ChangeColorOfButtonChildren()
        {
            _isBeingClicked = true;
            image.color = pressedColour;
            yield return new WaitForSeconds(0.1f);
            image.color = Color.white;
            _isBeingClicked = false;
        }
    }
}
