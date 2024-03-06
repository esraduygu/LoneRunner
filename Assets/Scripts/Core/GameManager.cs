using System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Playing,
            Paused
        }
    
        public GameState State { get; private set; }
        public Action<GameState> OnStateChange;

        public float initialGameSpeed;
        public float gameSpeedIncrease;
        public float gameSpeed;
        public float maxGameSpeed;

        public void StopPlaying()
        {
            gameSpeed = 0f;
            UpdateState(GameState.Paused);
        }
        private void Awake()
        {
            StartPlaying();
        }

        private void Update()
        {
            if (State == GameState.Playing)
                IncreaseGameSpeedPerFrame();
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
