using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainGenerator
{
    public static Texture2D GenerateTexture(float[,] data)
    {
        int width = data.GetLength(0);
        int height = data.GetLength(1);

        Texture2D texture = new Texture2D(data.GetLength(0), data.GetLength(1));
        Color[] colors = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int i = x + width * y;
                float value = data[x,y];
                colors[i] = new Color(value, value, value);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }

    public static float[,] IslandFilter(float[,] data, float innerRadius, float outerRadius)
    {
        float multiplier;
        int width = data.GetLength(0);
        int height = data.GetLength(1);

        // Get the middle point by halving heightn and width
        Vector2Int middlePoint = new Vector2Int(width/2, height/2);

        // Make a for loop that compares the distance of the current data point to the outer- and inner radius, then acts accordingly
        for (int y = 0; y < data.GetLength(1); y++)
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                Vector2Int point = new Vector2Int(x, y);
                float d = Vector2.Distance(point, middlePoint);

                if (d < innerRadius)
                {
                    multiplier = 1;
                }
                else if (d > outerRadius)
                {
                    multiplier = 0;
                }
                else
                {
                    multiplier = MapUtil.Map(d, innerRadius, outerRadius, 1, 0);
                }

                // manipulate the point by useing the multiplier
                data[x, y] *= multiplier;
            }
        }

        return data;
    }

    // returns a multidimenional array
    public static float[,] GenerateNoiseData(int width, int height, float scale, float baseAmplitude, int octaves, float lacunarity, float persistence, Vector3 offset)
    {
        float[,] result = new float[width, height];

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[x, y] = 0f;
                float frequency = scale;
                float amplitude = baseAmplitude;

                for (int o = 0; o < octaves; o++)
                {
                    frequency *= lacunarity;
                    amplitude *= persistence;
                    result[x, y] += (GetPerlinValue(x + offset.x, y + offset.y, frequency, amplitude) + offset.z/100);

                    // If the new result is greater or smaller than the previous min and max values, set that as the new min and max
                    if (result[x, y] > maxValue)
                    {
                        maxValue = result[x, y];
                    }
                    if (result[x, y] < minValue)
                    {
                        minValue = result[x, y];
                    }
                }
            }
        }

        //for (int y = 0; y < height; y++)
        //{
        //    for (int x = 0; x < width; x++)
        //    {
        //        result[x, y] = Mathf.InverseLerp(minValue, maxValue, result[x, y]*baseAmplitude);
        //    }
        //}

        return result;
    }

    [Serializable]
    public struct LayerData
    {
        public string layerName;
        public float heightTrigger;
        public float fadeAmount;

        public LayerData(string layerName, float heightTrigger, float fadeAmount)
        {
            this.layerName = layerName;
            this.heightTrigger = heightTrigger;
            this.fadeAmount = fadeAmount;
        }
    }

    public static float[,,] GenerateTextureData(float[,] terrainData, LayerData[] layers)
    {
        int width = terrainData.GetLength(0);
        int height = terrainData.GetLength(1);
        float[,,] map = new float[width, height, layers.Length];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float value = terrainData[x, y];

                for (int l = 0; l < layers.Length; l++)
                {
                    float mapValue;

                    if (l == 0)
                    {
                        mapValue = Mathf.Clamp (MapUtil.Map(value, layers[l].heightTrigger, layers[l].heightTrigger + layers[l].fadeAmount, 1, 0), 0, 1);
                    }
                    else
                    {
                        if (value > layers[l].heightTrigger)
                        {
                            // Fade up
                            mapValue = Mathf.Clamp(MapUtil.Map(value, layers[l].heightTrigger, layers[l].heightTrigger + layers[l].fadeAmount, 1, 0), 0, 1);
                        }
                        else if (value < layers[l-1].heightTrigger + layers[l-1].fadeAmount)
                        {
                            // Fade down
                            mapValue = Mathf.Clamp(MapUtil.Map(value, layers[l-1].heightTrigger, layers[l-1].heightTrigger + layers[l-1].fadeAmount, 0, 1), 0, 1);
                        }
                        else
                        {
                            // Middle
                            mapValue = 1;
                        }

                        //mapValue = value < layers[l].heightTrigger && value > layers[l - 1].heightTrigger ? 1.0f : 0.0f;
                    }

                    map[x, y, l] = mapValue;
                }
            }
        }

        return map;
    }

    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = (Mathf.PerlinNoise(x*frequency, y*frequency) * 2f - 1) * amplitude;

        return result;
    }
}
