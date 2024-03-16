using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utilities;
using Random = UnityEngine.Random;

namespace Background
{
    public class GroundGenerator : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Tilemap groundTileMap;
        [SerializeField] private Tilemap undergroundTileMap;
        [SerializeField] private Tile groundTile;
        [SerializeField] private Tile[] undergroundTiles;

        private Vector3Int _startingPos = new(10, -2, 0);
        private float _movementSinceLastTile = 16;
        private List<int> _lastSpawnedUndergroundTileIndices = new();

        private void Update()
        {
            var moveAmount = gameManager.gameSpeed * Time.deltaTime;
            transform.position += Vector3.left * moveAmount;

            _movementSinceLastTile += moveAmount;
            while (_movementSinceLastTile > 16)
            {
                groundTileMap.SetTile(_startingPos, groundTile);
                SetUndergroundTiles();
                
                _startingPos.x++;
                _movementSinceLastTile -= 16;
            }
        }

        private void SetUndergroundTiles()
        {
            var randomAmount = MathUtilities.PickOne(0.75f, 0.2f, 0.05f);
            var spawnedIndices = new List<int>();
            
            while (randomAmount > 0)
            {
                var availableIndices = Enumerable.Range(0, undergroundTiles.Length)
                    .Where(x => !spawnedIndices.Contains(x) && !_lastSpawnedUndergroundTileIndices.Contains(x))
                    .ToArray();
                
                if (availableIndices.Length <= 0) break;

                var randomIndex = availableIndices[Random.Range(0, availableIndices.Length)];
                if (randomIndex == 0 && availableIndices.Length > 1)
                    randomIndex = availableIndices[Random.Range(0, availableIndices.Length)];

                spawnedIndices.Add(randomIndex);
                
                var spawnPos = _startingPos;
                spawnPos.y -= randomIndex == 0 ? MathUtilities.PickOne(0, 0.7f, 0.3f) : MathUtilities.PickOne(0.7f, 0.25f, 0.05f);
                undergroundTileMap.SetTile(spawnPos, undergroundTiles[randomIndex]);
                randomAmount--;
            }
            
            if (spawnedIndices.Any())
                _lastSpawnedUndergroundTileIndices = spawnedIndices;
        }
    }
}