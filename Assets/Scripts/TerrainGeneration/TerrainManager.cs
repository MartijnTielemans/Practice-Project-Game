using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : TerrainConfig
{
    Terrain terrain;

    [Header("Terrain Texture Settings")]
    public List<TerrainGenerator.LayerData> layers;

    protected override void UpdateTerrainData(float[,] data)
    {
        terrain = Terrain.activeTerrain;
        terrain.terrainData.heightmapResolution = size.x;
        terrain.terrainData.SetHeights(0, 0, data);
        UpdateTerrainTexture(data);
    }

    protected void UpdateTerrainTexture(float[,] data)
    { 
        terrain = Terrain.activeTerrain;
        terrain.terrainData.alphamapResolution = size.x;
        terrain.terrainData.SetAlphamaps(0, 0, TerrainGenerator.GenerateTextureData(data, layers.ToArray()));
    }
}
