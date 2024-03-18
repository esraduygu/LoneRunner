using TMPro;
using UnityEngine;

namespace UI
{
    public class BlinkingText : MonoBehaviour
    {
        [Range(1, 10)] public float blinkingRate;

        [SerializeField] private TMP_Text text;

        private void Update()
        {
            Blink();
        }

        private void Blink()
        {
            text.alpha = Mathf.Sin(Time.time * blinkingRate) >= 0 ? 1 : 0;
        }
    }
}