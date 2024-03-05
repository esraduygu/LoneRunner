using System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Playing,
        }
    
        public GameState State { get; private set; }
        public Action<GameState> OnStateChange;

        public float initialGameSpeed = 100f;
        public float gameSpeedIncrease = 0.1f;
        public float gameSpeed;

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
        }
    
        private void UpdateState(GameState state)
        {
            State = state;
            OnStateChange?.Invoke(state);
        }
    }
}
