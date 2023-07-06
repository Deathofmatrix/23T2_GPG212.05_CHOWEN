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
                collision.gameObject.GetComponent<CharacterController>().ChangeDirection();

                /*for (int i = 0; i < collision.contactCount; i++)
                {
                    if (Vector2.Angle(collision.contacts[i].normal, Vector2.left) <= 80f || Vector2.Angle(collision.contacts[i].normal, Vector2.right) <= 80f)
                    {
                        
                    }
                }*/
            }
        }
    }
}
