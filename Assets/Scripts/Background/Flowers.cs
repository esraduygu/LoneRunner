using UnityEngine;

namespace Background
{
    public class Flowers : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
            
            if (transform.position.x <= -360)
                Destroy(gameObject);
        }
    }
}