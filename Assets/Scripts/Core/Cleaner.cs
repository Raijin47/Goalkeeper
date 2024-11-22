using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ProjectileBase obj))
        {
            obj.Dispose();
        }
    }
}