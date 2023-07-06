using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelDesignSim
{
    public class ChangeDirection : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector2 direction = collision.GetContact(0).normal;
                if (direction.x == 1 || direction.x == -1)
                {
                    collision.gameObject.GetComponent<CharacterController>().ChangeDirection();
                }
            }
        }
    }
}
