using Unity.Mathematics;
using UnityEngine;
using Utilities;

namespace Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Obstacle[] obstaclePrefabs;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacles), 0, 2f);
        }

        private void SpawnObstacles()
        {
            const float easyProbability = 0.5f;
            const float normalProbability = 0.4f;
            const float hardProbability = 0.1f;
            
            var index = MathUtilities.PickOne(easyProbability, normalProbability, hardProbability);

            Instantiate(obstaclePrefabs[index], transform.position, quaternion.identity);
        }
    }
}
