using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    private Vector3 target;
    public GameObject bulletPrefab;

    public float bulletSpeed = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in world space
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        // Update crosshair position to follow the mouse
        crosshairs.transform.position = new Vector2(target.x, target.y);

        // Calculate direction for bullet firing (without rotating the player)
        Vector3 difference = target - player.transform.position;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;  // Normalize direction for firing

        // If the player clicks the mouse, fire a bullet
        if (Input.GetMouseButtonDown(0))
        {
            fireBullet(direction);
        }
    }

    void fireBullet(Vector2 direction)
    {
        // Instantiate and fire the bullet
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;

        // Set the bullet's velocity based on the direction
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
