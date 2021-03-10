using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : TerrainConfig
{
    protected override void UpdateTerrainData(float[,] data)
    {
        Terrain terrain = Terrain.activeTerrain;
        terrain.terrainData.heightmapResolution = size.x;
        terrain.terrainData.SetHeights(0, 0, data);
    }
}
