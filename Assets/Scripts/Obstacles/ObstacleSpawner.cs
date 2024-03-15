using Core;
using Unity.Mathematics;
using UnityEngine;
using Utilities;

namespace Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Obstacle[] obstaclePrefabs;
        [SerializeField] private GameManager gameManager;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacles), 0, 2f);
        }

        private void SpawnObstacles()
        {
            if (gameManager.State != GameManager.GameState.Playing)
                return;
            
            const float easyProbability = 0.4f;
            const float normalProbability = 0.3f;
            const float hardProbability = 0.2f;
            const float extremeProbability = 0.1f;
            
            var index = MathUtilities.PickOne(easyProbability, normalProbability, hardProbability, extremeProbability);

            var obstaclePrefab = obstaclePrefabs[index];
            var spawnPos = transform.position;
            spawnPos.y += obstaclePrefab.transform.position.y;
            
            Instantiate(obstaclePrefab, spawnPos, quaternion.identity);
        }
    }
}
