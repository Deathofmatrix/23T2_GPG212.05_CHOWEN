using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelDesignSim
{
    public class CharacterController : MonoBehaviour
    {
        private Rigidbody2D _rigibody2D;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float jumpDelay;
        [SerializeField] private int directionX = 1;

        void Start()
        {
            _rigibody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            _rigibody2D.velocity = new Vector2(directionX * speed, _rigibody2D.velocity.y);
        }

        public void ChangeDirection()
        {
            directionX = directionX > 0 ? -1 : 1;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }

        public void Jump()
        {
            StartCoroutine(JumpCO(jumpDelay));
        }

        private IEnumerator JumpCO(float delay)
        {
            yield return new WaitForSeconds(delay);
            _rigibody2D.velocity = new Vector2(_rigibody2D.velocity.x, jumpHeight);
        }

        private void OnDisable()
        {
            Flag.noOfPlayersInactive++;
        }
    }
}

