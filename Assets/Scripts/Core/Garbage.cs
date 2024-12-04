using UnityEngine;

public class Garbage : ProjectileBase
{
    public SpriteRenderer sr;
    public Sprite[] sprites;

    private void OnEnable() 
    {
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public override void ResetData()
    {
        FadeValue = 1;
    }
}