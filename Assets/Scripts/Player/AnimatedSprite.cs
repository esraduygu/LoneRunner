using Core;
using UnityEngine;

namespace Player
{
    public class AnimatedSprite : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float baseFps;
        
        private SpriteRenderer _spriteRenderer;
        private int _frame;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (gameManager.State == GameManager.GameState.Playing)
                Animate();
                
        }

        private void Animate()
        {
            var fps = baseFps * gameManager.gameSpeed;
            var spriteIndex = Mathf.FloorToInt(Time.time % 1 * fps) % sprites.Length;
            _spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
}