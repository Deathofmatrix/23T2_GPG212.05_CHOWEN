using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelDesignSim
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rB2D;
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private int directionX = 1;

        void Start()
        {
            rB2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            rB2D.velocity = new Vector2(directionX * speed, rB2D.velocity.y);
        }

        public void ChangeDirection()
        {
            directionX = directionX > 0 ?-1 : 1;
        }
    }
}

