using System;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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
            
            var index = PickOne(easyProbability, normalProbability, hardProbability);

            Instantiate(obstaclePrefabs[index], transform.position, quaternion.identity);
        }
        
        public static int PickOne(params float[] probabilities)
        {
            var probabilityIndices = probabilities
                .Select((value, index) => new { value, index })
                .ToDictionary(p => p.index, p => p.value)
                .OrderBy(x => x.Value);

            var random = Random.value;
            foreach (var (index, probability) in probabilityIndices)
            {
                random -= probability;

                if (random < 0)
                    return index;
            }

            return -1;
        }
    }
}
