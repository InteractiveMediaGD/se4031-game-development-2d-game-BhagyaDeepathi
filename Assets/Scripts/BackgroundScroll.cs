using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float backgroundHeight = 20f;

    void Update()
    {
        // Move background down
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Loop background when it goes off screen
        if (transform.position.y <= -backgroundHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (backgroundHeight * 2), transform.position.z);
        }
    }
}
