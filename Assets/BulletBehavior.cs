using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f; // Time before the bullet destroys itself

    private void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy the bullet after a set lifetime
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy bullet on collision
        Destroy(gameObject);
    }
}
