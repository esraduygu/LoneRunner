using Core;
using UnityEngine;

namespace Background
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        
        private Vector3 _internalPosition;

        private void Awake()
        {
            _internalPosition = transform.position;
        }

        private void Update()
        {
            if (gameManager.State == GameManager.GameState.Playing)
                Move();
        }

        private void Move()
        {
            _internalPosition += Vector3.left * (gameManager.gameSpeed * Time.deltaTime);
            
            if (_internalPosition.x < -320)
                _internalPosition.x = 320;

            transform.position = Vector3Int.FloorToInt(_internalPosition);
        }
    }
}