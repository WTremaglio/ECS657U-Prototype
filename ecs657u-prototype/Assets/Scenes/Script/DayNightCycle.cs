using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;
    public float dayLengthInSeconds = 90f;
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float zombieSpawnInterval = 5f;
    public int maxZombiesDay = 10;
    public int maxZombiesNight = 25;

    private bool isNight = false;
    private List<GameObject> activeZombies = new List<GameObject>();  // Track active zombies
    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = zombieSpawnInterval;
        InvokeRepeating("SpawnZombies", 0f, currentSpawnInterval);
    }

    void Update()
    {
        // Rotate the directional light to simulate the day-night cycle
        float rotationSpeed = 360f / dayLengthInSeconds;
        directionalLight.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        float currentRotationX = directionalLight.transform.eulerAngles.x;
        isNight = currentRotationX > 180f;

        // spawn interval based on day or night
        if (isNight)
        {
            if (currentSpawnInterval != zombieSpawnInterval / 2f)  // Faster spawn at night
            {
                CancelInvoke("SpawnZombies");
                currentSpawnInterval = zombieSpawnInterval / 2f;
                InvokeRepeating("SpawnZombies", 0f, currentSpawnInterval);
            }
        }
        else
        {
            if (currentSpawnInterval != zombieSpawnInterval)  // Slower spawn during the day
            {
                CancelInvoke("SpawnZombies");
                currentSpawnInterval = zombieSpawnInterval;
                InvokeRepeating("SpawnZombies", 0f, currentSpawnInterval);
            }
        }

       
        activeZombies.RemoveAll(zombie => zombie == null);
    }

    void SpawnZombies()
    {
        int maxZombies = isNight ? maxZombiesNight : maxZombiesDay;

        if (zombiePrefab != null && activeZombies.Count < maxZombies)  // Ensure the prefab is assigned 
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            GameObject newZombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            activeZombies.Add(newZombie);  // Add zombie to the list
            Debug.Log("Spawned Zombie at: " + spawnPoint.position);
        }
        else if (activeZombies.Count >= maxZombies)
        {
            Debug.Log("Max zombie limit reached: " + activeZombies.Count);
        }
        else
        {
            Debug.LogError("Zombie prefab is not assigned in the inspector.");
        }
    }
}




