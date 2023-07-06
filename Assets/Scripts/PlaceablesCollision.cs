using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelDesignSim
{
    public class PlaceablesCollision : MonoBehaviour
    {
        private bool _isCollidingWithPlaceable = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Placeable"))
            {
                _isCollidingWithPlaceable = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Placeable") && _isCollidingWithPlaceable)
            {
                _isCollidingWithPlaceable = false;
            }
        }

        /*public void OnClick(InputAction.CallbackContext ctx)
        {
            if (ctx.canceled && _isCollidingWithPlaceable)
            {
                Destroy(gameObject);
            }
        }*/

        private void Update()
        {
            if(Input.GetMouseButtonUp(0) && _isCollidingWithPlaceable)
            {
                Destroy(gameObject);
            }
        }
    }
}
