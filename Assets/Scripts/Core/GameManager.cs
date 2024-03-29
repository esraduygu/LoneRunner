using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            StartMenu,
            Playing,
            GameOver
        }
    
        public GameState State { get; private set; }
        public Action<GameState> OnStateChange;

        public float initialGameSpeed;
        public float gameSpeedIncrease;
        public float gameSpeed;
        public float maxGameSpeed;
        public float score;
        public float bestScore;
        
        private void Awake()
        {
            bestScore = PlayerPrefs.GetFloat("BestScore");
        }
        
        private void Update()
        {
            if (State == GameState.Playing)
                IncreaseGameSpeedPerFrame();

            UpdateScore();

            if (State is GameState.StartMenu && Input.anyKey)
            {
                StartPlaying();
            }
        }
        
        private void StartPlaying()
        {
            gameSpeed = initialGameSpeed;
            UpdateState(GameState.Playing);
        }
        
        public void Restart()
        {
            SceneManager.UnloadScene(0);
            SceneManager.LoadScene(0);
        }
        
        public void StopPlaying()
        {
            gameSpeed = 0f;
            UpdateState(GameState.GameOver);
        }
        
        private void IncreaseGameSpeedPerFrame()
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
            gameSpeed = Mathf.Clamp(gameSpeed, initialGameSpeed, maxGameSpeed);
        }
        
        private void UpdateScore()
        {
            score += gameSpeed / 100 * Time.deltaTime;

            if (score > bestScore)
            {
                bestScore = score;
                PlayerPrefs.SetFloat("BestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
        
        private void UpdateState(GameState state)
        {
            State = state;
            OnStateChange?.Invoke(state);
        }
    }
}
