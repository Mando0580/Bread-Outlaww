using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Player's movement speed
    public GameObject bulletPrefab;       // Bullet prefab
    public Transform shootingPoint;       // The point from where the bullet will spawn
    public float bulletSpeed = 10f;       // Bullet speed

    private void Update()
    {
        MovePlayer();         // Call movement
        if (Input.GetMouseButtonDown(0)) // Shoot when the left mouse button is clicked
        {
            Shoot();
        }
    }

    // Handles player movement
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    // Shoots a bullet towards the mouse direction
    void Shoot()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component and set its velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Calculate the direction to shoot (normalized vector towards the mouse)
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootingPoint.position).normalized;

        // Set the velocity of the bullet in the direction of the mouse
        rb.velocity = direction * bulletSpeed;
    }
}
