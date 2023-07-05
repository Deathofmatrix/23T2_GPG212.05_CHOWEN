using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelDesignSim
{
    public class MatchButtonColour : MonoBehaviour
    {
        private Image image;
        private Color pressedColour = new Color32(200, 200, 200, 255);

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void ChangeChildColour()
        {
            StartCoroutine(ChangeColorOfButtonChildren());
        }

        private IEnumerator ChangeColorOfButtonChildren()
        {
            image.color = pressedColour;
            yield return new WaitForSeconds(0.1f);
            image.color = Color.white;
        }
    }
}
