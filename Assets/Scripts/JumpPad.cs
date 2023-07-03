using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    public class JumpPad : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<CharacterController>().Jump();
            }
        }
    }
}
