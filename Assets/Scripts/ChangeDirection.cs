using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    public class ChangeDirection : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<CharacterController>().ChangeDirection();
            }
        }
    }
}
