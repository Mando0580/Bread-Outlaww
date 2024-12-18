using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // The projectile to instantiate
    public float projectileSpeed = 10f;  // The speed at which the projectile moves

    // Update is called once per frame
    void Update()
    {
        // Check for the left mouse button click (or any input you prefer)
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse position
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Add velocity to the projectile in the direction of the mouse
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }
}
