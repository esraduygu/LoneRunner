﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Background
{
    public class FlowerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] flowerPrefabs;
        
        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 1, 2.5f);
        }

        private void Spawn()
        {
            var randomIndex = Random.Range(0, flowerPrefabs.Length + 4);
            if (randomIndex >= flowerPrefabs.Length)
                return;
            
            Instantiate(flowerPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
        
        

    }
}