using UnityEngine;

public class Ball : ProjectileBase
{
    [SerializeField] private Collider2D _collider;

    public Collider2D Collider => _collider;

    public override void ResetData()
    {
        Collider.enabled = true;
        FadeValue = 1;
    }
}