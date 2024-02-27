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

        public float speed = 20;
        private float _cellsToFillThisFrame;
        private int _lastFilledCellX;
        private int _tilemapWidth;

        private void Start()
        {
            _tilemapWidth = foregroundTilemap.size.x;
        }

        private void Update()
        {
            var position = new Vector3Int(-1, -4);
            backgroundTilemap.SetTile(position, backgroundTiles[0]);

            var foregroundMovementAmount = Vector3.left * (Time.deltaTime * speed);
            foregroundTilemap.transform.position += foregroundMovementAmount;

            var tilePerUnit = foregroundTilemap.WorldToCell(Vector2.one);
            // _cellsToFillThisFrame += foregroundTilemap.size.x / tilePerUnit.x;
            if (tilePerUnit.x != 0)
                _cellsToFillThisFrame += Mathf.FloorToInt(foregroundTilemap.size.x / tilePerUnit.x);
            
            
            int maxIterations = 1000;
            int iterations = 0;
            
            while (_cellsToFillThisFrame >= 1  && iterations < maxIterations)
            {
                _lastFilledCellX = foregroundTilemap.size.x + 1;
                var fillPosition = new Vector3Int(_lastFilledCellX, -3);
                foregroundTilemap.SetTile(fillPosition, foregroundTiles[0]);
                _lastFilledCellX++;
                _cellsToFillThisFrame--;
            }
        }
    }
}
