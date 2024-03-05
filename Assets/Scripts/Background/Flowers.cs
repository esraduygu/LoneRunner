using Core;
using UnityEngine;

namespace Background
{
    public class Flowers : MonoBehaviour
    { 
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (_gameManager.State == GameManager.GameState.Playing)
                Move();
        }

        private void Move()
        {
            transform.position += Vector3.left * (_gameManager.gameSpeed * Time.deltaTime);
            
            if (transform.position.x <= -360)
                Destroy(gameObject);
        }
    }
}