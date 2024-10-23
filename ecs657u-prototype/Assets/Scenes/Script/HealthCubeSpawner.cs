using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;    
    public int numberOfCubes = 30;   //number of cubes to be spawned

    void Start()
    {
        SpawnCubes();
    }

   void SpawnCubes()
{
    Terrain terrain = Terrain.activeTerrain;

    if (terrain == null)
    {
        Debug.LogError("No active terrain found.");
        return;
    }

    for (int i = 0; i < numberOfCubes; i++)
    {
        float randomX = Random.Range(0, terrain.terrainData.size.x); //spawned randomly around map
        float randomZ = Random.Range(0, terrain.terrainData.size.z);
        float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + (cubePrefab.GetComponent<Collider>().bounds.extents.y) + 0.5f;

        Vector3 spawnPosition = new Vector3(randomX, y, randomZ);
        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
    }
}
} 