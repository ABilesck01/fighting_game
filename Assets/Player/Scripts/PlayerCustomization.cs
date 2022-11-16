using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
