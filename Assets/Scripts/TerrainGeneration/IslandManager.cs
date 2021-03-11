using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : TerrainManager
{
    public float innerRadius;
    public float outerRadius;

    protected override void UpdateTerrainData(float[,] data)
    {
        data = TerrainGenerator.IslandFilter(data, innerRadius, outerRadius);

        base.UpdateTerrainData(data);
    }
}
