using Core;
using UnityEngine;

namespace Player
{
    public class AnimatedSprite : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Player player;
        [SerializeField] private Animator animator;
        
        private static readonly int SpeedHash = Animator.StringToHash("speed");
        private static readonly int IsJumpingHash = Animator.StringToHash("isJumping");

        private void Update()
        {
            SetAnimationSpeed();
            SetAnimationJumping();
        }

        private void SetAnimationSpeed()
        {
            if (gameManager.State == GameManager.GameState.Playing)
                animator.SetFloat(SpeedHash, gameManager.gameSpeed / gameManager.initialGameSpeed);
        }

        private void SetAnimationJumping()
        {
            switch (player.State)
            {
                case Player.PlayerState.Jumping:
                    animator.SetBool(IsJumpingHash, true);
                    break;
                case Player.PlayerState.Grounded:
                    animator.SetBool(IsJumpingHash, false);
                    break;
            }
        }
    }
}