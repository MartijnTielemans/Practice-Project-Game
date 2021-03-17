using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGeneration : TerrainConfig
{
    public GameObject mapSquare;
    public GameObject terrainParent;

    protected override void UpdateTerrainData(float[,] data)
    {
        GameObject[,] mapTiles = new GameObject[size.x, size.y];

        // Destroy the old terrain first
        //foreach  (Transform child in terrainParent.transform)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}

        // Instantiate new terrain
        //for (int x = 0; x < size.x; x++)
        //{
        //    for (int y = 0; y < size.y; y++)
        //    {
        //        Vector3 location = new Vector3(x * 2, 0, y * 2);
        //        mapTiles[x, y] = Instantiate(mapSquare, location, mapSquare.transform.rotation);
        //        mapTiles[x, y].transform.parent = terrainParent.transform;
        //    }
        //}
    }
}
