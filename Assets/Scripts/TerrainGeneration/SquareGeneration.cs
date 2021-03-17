using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGeneration : TerrainConfig
{
    [Header("Island Settings")]
    public float multiplier;

    public float innerRadius;
    public float outerRadius;

    public bool isIsland = true;

    [Header("!! ONLY ENABLE IF YOU NEED NEW TERRAIN !!")]
    public bool generateTerrain = false;

    public GameObject mapSquare;
    public GameObject terrainParent;

    protected override void UpdateTerrainData(float[,] data)
    {
        // Make the map tile array
        GameObject[,] mapTiles = new GameObject[size.x, size.y];

        if (generateTerrain)
        {
            // Instantiate new terrain
            TerrainGeneration(mapTiles);
        }

        int xTile = 0;
        int yTile = 0;

        // For every tile that has been spawned, add it to the list
        foreach (Transform child in terrainParent.transform)
        {
            mapTiles[xTile, yTile] = child.gameObject;
            yTile++;

            if (yTile > size.y-1)
            {
                yTile = 0;
                xTile++;
            }
        }

        if (isIsland)
        {
            data = TerrainGenerator.IslandFilter(data, innerRadius, outerRadius);
        }

        // Apply the new heights to the tiles
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                GameObject mapTile = mapTiles[x, y];
                mapTile.transform.localScale = new Vector3(mapTile.transform.localScale.x, mapTile.transform.localScale.y, data[x, y]*multiplier);
                mapTile.transform.localPosition = new Vector3(mapTile.transform.position.x, mapTile.transform.localScale.z / 2, mapTile.transform.position.z);
            }
        }
    }

    void TerrainGeneration(GameObject[,] mapTiles)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 location = new Vector3(x * 2, 0, y * 2);
                mapTiles[x, y] = Instantiate(mapSquare, location, mapSquare.transform.rotation);
                mapTiles[x, y].transform.parent = terrainParent.transform;
            }
        }
    }
}
