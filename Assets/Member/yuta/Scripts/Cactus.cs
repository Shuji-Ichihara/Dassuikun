using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Sprite Cactus_Cat;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    public void Cat_Cactus()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = Cactus_Cat;
        boxCollider2D.enabled = false;
    }
}
