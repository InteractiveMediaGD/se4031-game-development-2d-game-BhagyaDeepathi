using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 5f;
    private float height;

    void Start()
    {
        // Calculate the height of the sprite
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log(gameObject.name + " height: " + height);
    }

    void Update()
    {
        // Move sprite down
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Reset position when sprite goes off screen (adjusted for safety)
        if (transform.position.y <= -height * 0.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (height * 2), transform.position.z);
            Debug.Log(gameObject.name + " reset position");
        }
    }
}
