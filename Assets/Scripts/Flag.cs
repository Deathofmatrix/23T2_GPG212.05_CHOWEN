using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LevelDesignSim
{
    public class Flag : MonoBehaviour
    {
        public static int noOfPlayersInactive = 0;
        [SerializeField] private int noOfPlayersFinished = 0;
        [SerializeField] private GameObject finishedPanel;
        [SerializeField] private TextMeshProUGUI finishedText;
        private TextMeshProUGUI finishedTitle;

        private void Start()
        {
            noOfPlayersInactive = 0;
            finishedTitle = finishedPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
                noOfPlayersFinished++;
            }
        }

        private void Update()
        {
            if (noOfPlayersInactive == 3)
            {
                Debug.Log("All players finished");
                //display level finished canvas
                //then load next level
                if (noOfPlayersFinished == 0 ) { finishedTitle.text = "Uh Oh..."; }
                finishedPanel.SetActive(true);
                finishedText.text = $"{noOfPlayersFinished} players finished";
            }
        }
    }
}
