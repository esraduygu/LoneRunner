using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class BlinkingText : MonoBehaviour
    {
        [Range(1, 10)]
        public float blinkingRate;
        
        [SerializeField] private TMP_Text text;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioMixer mixer;

        private void Update()
        {
            // text.alpha = Mathf.Sin(Time.time * blinkingRate) > 0 ? 1 : 0;
            
            // text.alpha = mixer.
        }
    }
}