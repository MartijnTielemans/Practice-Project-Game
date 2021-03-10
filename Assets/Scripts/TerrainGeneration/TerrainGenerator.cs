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

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //result[x, y] = Mathf.InverseLerp(minValue, maxValue, result[x, y]*baseAmplitude);
            }
        }

        return result;
    }

    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = (Mathf.PerlinNoise(x*frequency, y*frequency) * 2f - 1) * amplitude;

        return result;
    }
}
