using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreLabel : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text bestScoreText;

        private void Update()
        {
            var score = Mathf.Clamp(gameManager.score, 0, 99999);
            currentScoreText.SetText(Mathf.FloorToInt(score).ToString("D5"));
            
            var bestScore = Mathf.Clamp(gameManager.bestScore, 0, 99999);
            bestScoreText.SetText(Mathf.FloorToInt(bestScore).ToString("D5"));
        }
    }
}