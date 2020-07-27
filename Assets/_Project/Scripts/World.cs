using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private Terrain _grassTerrain;
    [SerializeField] private Terrain _hillTerrain;
    [SerializeField] private Terrain _riverTerrain;

    private Terrain[,] _tiles;

    private void Awake()
    {
        _tiles = new Terrain[_width, _height];
        GenerateTerrain();
        SpawnTerrain();
    }

    private void SpawnTerrain()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                GameObject obj = new GameObject();
                obj.name = "tile [" + x + "][" + y + "]";
                obj.transform.position = new Vector2(x, y);
                obj.transform.SetParent(transform);
                SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
                renderer.sprite = _tiles[x, y].Sprite;
            }
        }
    }

    private void GenerateTerrain()
    {
        // Fill the ground with grass.
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                // Sprinkle some hills.
                if (Random.Range(0, _height) == 0)
                {
                    _tiles[x,y] = _hillTerrain;
                }
                else
                {
                    _tiles[x,y] = _grassTerrain;
                }
            }
        }

        int randomX = Random.Range(0, _width);

        for (int y = 0; y < _height; y++)
        {
            _tiles[randomX,y] = _riverTerrain;
        }
    }
}