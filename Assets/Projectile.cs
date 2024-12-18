using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;  // Time after which the projectile will be destroyed
    private float timeAlive = 0f;

    void Update()
    {
        // Destroy the projectile after its lifetime is over
        timeAlive += Time.deltaTime;
        if (timeAlive >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the projectile when it hits anything
        Destroy(gameObject);
    }
}
