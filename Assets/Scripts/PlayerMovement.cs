using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 20f;
    public float speedIncreaseRate = 0.1f;
    public GameObject bulletPrefab;
    public float fireRate = 0.1f;
    
    private float currentForwardSpeed;
    private float nextFireTime;

    void Start()
    {
        currentForwardSpeed = forwardSpeed;
        
        // Set Rigidbody2D interpolation to reduce jitter
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }

    void LateUpdate()
    {
        // Force Z position to 0 in LateUpdate to prevent flickering
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }

    void Update()
    {
        // Force Z position to 0 to prevent passing through glitches
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // Forward movement with gradually increasing speed
        currentForwardSpeed += speedIncreaseRate * Time.deltaTime;
        transform.Translate(Vector3.up * currentForwardSpeed * Time.deltaTime);

        // Fast horizontal movement (Left/Right)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);

        // Shooting with left mouse button
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            // Spawn bullet at player position (not attached to player)
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
