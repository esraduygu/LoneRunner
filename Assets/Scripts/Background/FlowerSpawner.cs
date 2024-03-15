using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Background
{
    public class FlowerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] flowerPrefabs;
        [SerializeField] private GameManager gameManager;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnFlowers), 1, 2.5f);
        }

        private void SpawnFlowers()
        {
            if (gameManager.State != GameManager.GameState.Playing)
                return;
            
            var randomIndex = Random.Range(0, flowerPrefabs.Length + 4);
            if (randomIndex >= flowerPrefabs.Length)
                return;
            
            Instantiate(flowerPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
    }
}