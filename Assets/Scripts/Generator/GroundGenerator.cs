using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Generator
{
    public class GroundGenerator : MonoBehaviour
    {
        [SerializeField] private Tilemap foregroundTilemap;
        [SerializeField] private Tilemap backgroundTilemap;
        [SerializeField] private Tile[] foregroundTiles;
        [SerializeField] private Tile[] backgroundTiles;

        public float speed = 10;
        private float _cellsToFillThisFrame;
        private int _lastFilledCellX;

        private void Update()
        {
            var position = new Vector3Int(-1, -4);
            backgroundTilemap.SetTile(position, backgroundTiles[0]);

            var foregroundMovementAmount = Vector3.left * Time.deltaTime * speed;
            foregroundTilemap.transform.position += foregroundMovementAmount;

            var tilePerUnit = foregroundTilemap.WorldToCell(Vector2.one);
            _cellsToFillThisFrame += foregroundMovementAmount.x / tilePerUnit.x;

            while (_cellsToFillThisFrame >= 1)
            {
                _lastFilledCellX++;
                var fillPosition = new Vector3Int(_lastFilledCellX, -3);
                foregroundTilemap.SetTile(fillPosition, foregroundTiles[0]);
                _cellsToFillThisFrame--;
            }
        }
        
    }
}
