using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum Type { Obstacle, HealthPack, Enemy }
    public Type type;
    public float fallSpeed = 0.05f;
    public int scoreValue = 10; // Points when destroyed

    void Update()
    {
        // Force Z position to 0 to prevent passing through glitches
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // Move downward
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            
            if (type == Type.Obstacle || type == Type.Enemy)
            {
                gm.TakeDamage(1);
            }
            else if (type == Type.HealthPack)
            {
                gm.AddHealth(1);
            }
            
            Destroy(gameObject);
        }
        else if (other.CompareTag("Projectile"))
        {
            if (type == Type.Enemy)
            {
                FindObjectOfType<GameManager>().AddScore(scoreValue);
                Destroy(gameObject); // Destroy enemy
            }
            Destroy(other.gameObject); // Destroy bullet
        }
    }
}
