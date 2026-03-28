using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 500f;
    
    void Update()
    {
        // Use transform.Translate for stable movement
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        // Destroy after 3 seconds
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy!");
            Destroy(other.gameObject); // Destroy Enemy
            Destroy(gameObject); // Destroy Bullet
            GameManager.instance.AddScore(10); // Add Score
        }
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
