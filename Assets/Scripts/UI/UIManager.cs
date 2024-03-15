using Core;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private RectTransform gameOverScreen;
        [SerializeField] private RectTransform gameScreen;
        [SerializeField] private RectTransform startScreen;

        private void Awake()
        {
            gameManager.OnStateChange += OnStateChange;
        }
        
        private void OnStateChange(GameManager.GameState state)
        {
            ClearScreens();

            if (state is GameManager.GameState.GameOver)
            {
                gameOverScreen.gameObject.SetActive(true);
                gameScreen.gameObject.SetActive(true);
            }
            else if (state is GameManager.GameState.Playing)
            {
                gameScreen.gameObject.SetActive(true);
            }
        }
        
        private void ClearScreens()
        {
            gameOverScreen.gameObject.SetActive(false);
            gameScreen.gameObject.SetActive(false);
            startScreen.gameObject.SetActive(false);
        }
    }
}
