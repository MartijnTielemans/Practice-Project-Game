using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float scrollX;
    public float scrollY;

    Renderer textureRenderer;

    private void Start()
    {
        textureRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;

        textureRenderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
