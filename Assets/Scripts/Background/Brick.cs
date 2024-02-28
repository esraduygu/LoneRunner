using UnityEngine;

namespace Background
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Vector3 _internalPosition;

        private void Awake()
        {
            _internalPosition = transform.position;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _internalPosition += Vector3.left * (speed * Time.deltaTime);
            
            if (_internalPosition.x < -320)
                _internalPosition.x = 320;

            transform.position = Vector3Int.FloorToInt(_internalPosition);
        }
    }
}