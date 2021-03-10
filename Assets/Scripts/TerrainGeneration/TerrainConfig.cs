using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainConfig : MonoBehaviour
{
    public Vector2Int size = new Vector2Int(512, 512);
    [Range(0.003f, 0.01f)]
    public float scale = 0.005f;
    [Range(0.05f, 1)]
    public float baseAmplitude = 1f;
    [Range(1, 10)]
    public int octaves = 4;
    [Range(1f, 3f)]
    public float lacunarity = 1.5f;
    [Range(0.01f, 1f)]
    public float persistence = 0.5f;
    public Vector3 offset = new Vector3(0, 0, 0);

    private void Start()
    {
        UpdateTerrainData(GenerateTerrainData());
    }

    float[,] GenerateTerrainData()
    {
        return TerrainGenerator.GenerateNoiseData(size.x, size.y, scale, baseAmplitude, octaves, lacunarity, persistence, offset);
    }

    protected virtual void UpdateTerrainData(float[,] data)
    {
        
    }

    // Generate the texture anew on validation
    private void OnValidate()
    {
        UpdateTerrainData(GenerateTerrainData());
    }
}
