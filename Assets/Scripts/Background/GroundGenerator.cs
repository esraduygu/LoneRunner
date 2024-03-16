using System;
using Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Background
{
    public class GroundGenerator : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Tilemap groundTileMap;
        [SerializeField] private Tile groundTile;

        private Vector3Int startingPos = new(10, -2, 0);
        private float movementSinceLastTile = 16;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            var moveAmount = gameManager.gameSpeed * Time.deltaTime;
            transform.position += Vector3.left * moveAmount;

            var ogMoveAmount = moveAmount;
            var i = 0;

            movementSinceLastTile += moveAmount;
            while (movementSinceLastTile > 16)
            {
                i++;
                groundTileMap.SetTile(startingPos, groundTile);
                startingPos.x++;
                movementSinceLastTile -= 16;
            }
            
            Debug.Log($"Spawned {i} tiles this frame. Moved {ogMoveAmount} pixels?");
        }
    }
}