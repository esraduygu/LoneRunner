using Core;
using UnityEngine;

namespace Obstacles
{
   [RequireComponent(typeof(BoxCollider2D))]
   public class Obstacle : MonoBehaviour
   {
      private GameManager _gameManager;

      private void Awake()
      {
         _gameManager = FindObjectOfType<GameManager>();
      }

      private void Update()
      {
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
