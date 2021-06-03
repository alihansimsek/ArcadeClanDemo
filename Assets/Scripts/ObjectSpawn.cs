using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject player;
    public GameObject[] cubePrefabs;
    public int cubeSpawnDistance = 5;
    public float cubeSpawnMaxLeft = -3f;
    public float cubeSpawnMaxRight = 3f;
    private Vector3 spawnObstaclePosition;

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if (distanceToHorizon < 120)
        {
            SpawnCubes();
        }
    }

    void SpawnCubes()
    {
        spawnObstaclePosition = new Vector3(Random.Range(cubeSpawnMaxLeft, cubeSpawnMaxRight), 0.5f, spawnObstaclePosition.z + cubeSpawnDistance);
        Instantiate(cubePrefabs[Random.Range(0, cubePrefabs.Length)], spawnObstaclePosition, Quaternion.identity);
    }
}
