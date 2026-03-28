using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform player;
    public float spawnDistance = 15f;
    public float spawnInterval = 0.3f;
    public float minSpawnInterval = 0.1f;
    public float spawnIntervalDecreaseRate = 0.1f;
    public float minX = -8f;
    public float maxX = 8f;

    private float nextSpawnTime;
    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = spawnInterval;
        nextSpawnTime = Time.time + currentSpawnInterval;
    }

    void Update()
    {
        // Use timer to spawn objects
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + currentSpawnInterval;

            // Decrease spawn interval over time (increase difficulty)
            currentSpawnInterval -= spawnIntervalDecreaseRate * Time.deltaTime;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
        }
    }

    void SpawnObstacle()
    {
        if (obstacles.Length == 0) return;

        // Select random obstacle from array
        GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];

        // Generate random X position
        float randomX = Random.Range(minX, maxX);

        // Spawn ahead of player
        Vector3 spawnPosition = new Vector3(randomX, player.position.y + spawnDistance, 0f);

        GameObject spawnedObject = Instantiate(randomObstacle, spawnPosition, Quaternion.identity);

        // Force Z position to 0 for spawned objects
        Vector3 pos = spawnedObject.transform.position;
        pos.z = 0f;
        spawnedObject.transform.position = pos;
    }
}
