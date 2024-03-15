using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
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
        

        public void StopPlaying()
        {
            gameSpeed = 0f;
            UpdateState(GameState.GameOver);
        }

        public void Restart()
        {
            //reset score
            SceneManager.UnloadScene(0);
            SceneManager.LoadScene(0);
        }
        
        private void Awake()
        {
            bestScore = PlayerPrefs.GetFloat("BestScore");
            
            StartPlaying();
        }

        private void Update()
        {
            if (State == GameState.Playing)
                IncreaseGameSpeedPerFrame();

            UpdateScore();
        }

        private void UpdateScore()
        {
            score += gameSpeed * Time.deltaTime;

            if (score > bestScore)
            {
                bestScore = score;
                PlayerPrefs.SetFloat("BestScore", bestScore);
                PlayerPrefs.Save();
            }
        }

        private void StartPlaying()
        {
            gameSpeed = initialGameSpeed;
            UpdateState(GameState.Playing);
        }
        
        private void IncreaseGameSpeedPerFrame()
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
            gameSpeed = Mathf.Clamp(gameSpeed, initialGameSpeed, maxGameSpeed);
        }
        
        private void UpdateState(GameState state)
        {
            State = state;
            OnStateChange?.Invoke(state);
        }
    }
}
