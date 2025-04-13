using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minInterval = 1f;
    public float maxInterval = 3f;

    private float timer;
    private float currentInterval;

    void Start()
    {
        SetRandomInterval();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentInterval)
        {
            SpawnObject();
            timer = 0f;
            SetRandomInterval();
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f); // Rotates car 180° on the Y-axis to face the opposite direction
        Instantiate(objectToSpawn, spawnPosition, spawnRotation);
    }

    void SetRandomInterval()
    {
        currentInterval = Random.Range(minInterval, maxInterval);
    }
}
