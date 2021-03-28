using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapDisplay : TerrainConfig
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    protected override void UpdateTerrainData(float[,] data)
    {
        base.UpdateTerrainData(data);

        if (material != null)
        {
            material.mainTexture = TerrainGenerator.GenerateTexture(data);
            material.mainTexture.filterMode = FilterMode.Point;
            material.mainTexture.wrapMode = TextureWrapMode.Clamp;
        }
    }
}
