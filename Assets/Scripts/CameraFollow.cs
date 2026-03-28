using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = -3f;

    void LateUpdate()
    {
        if (player == null) return;

        // Follow player only on Y axis, keep X and Z constant
        Vector3 newPosition = transform.position;
        newPosition.y = player.position.y + yOffset;
        transform.position = newPosition;
    }
}
