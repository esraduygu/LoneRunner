using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SfxManager : MonoBehaviour
    {
        public enum SfxType
        {
            Jump = 0,
            Hit = 1,
            Die = 2
        }
        
        [SerializeField] private List<AudioClip> clips;

        private Vector3 _cameraPosition;
        
        private void Awake()
        {
            if (Camera.main != null) 
                _cameraPosition = Camera.main.transform.position;
        }
        
        public void PlaySound(params SfxType[] sfxTypes)
        {
            foreach (var sfxType in sfxTypes)
            {
                AudioSource.PlayClipAtPoint(clips[(int)sfxType], _cameraPosition);
            }
        }
    }
}