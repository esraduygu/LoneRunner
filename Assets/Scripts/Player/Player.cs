using Core;
using Obstacles;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public enum PlayerState
        {
            Grounded,
            Jumping,
            Dead
        }

        public PlayerState State { get; private set; }
        
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CharacterController characterCont;
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravity;

        private Vector3 _direction;
        
        private void OnEnable()
        {
            _direction = Vector3.zero;
            
        }

        private void Update()
        {
           Jump();
        }

        private void Jump()
        {
            _direction += Vector3.down * (gravity * Time.deltaTime);

            if (characterCont.isGrounded)
            {
                _direction = Vector3.down;
                State = PlayerState.Grounded;

                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    _direction = Vector3.up * jumpForce;
                    State = PlayerState.Jumping;
                }
                
            }
            characterCont.Move(_direction * Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider collision)
        {
            if (gameManager.State != GameManager.GameState.Playing)
                return;
         
            if (collision.gameObject.GetComponent<Obstacle>() == null) 
                return;

            Destroy(gameObject);

            gameManager.StopPlaying();
        }

       
    }
}