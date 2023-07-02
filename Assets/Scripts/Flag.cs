using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    public class Flag : MonoBehaviour
    {
        [SerializeField] private int noOfPlayersFinished = 0;
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
            if (noOfPlayersFinished == 3)
            {
                Debug.Log("All players finished");
                //display level finished canvas
                //then load next level
            }
        }
    }
}
