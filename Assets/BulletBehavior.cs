using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float lifeTime = 2f;  // Bullet lifetime in seconds

    void Start()
    {
        Destroy(gameObject, lifeTime);  // Destroy bullet after time expires
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  // Destroy enemy when hit by bullet
            Destroy(gameObject);  // Destroy the bullet
        }
    }
}
