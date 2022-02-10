using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 5f;
    public GameObject ObjToSpawn;
    public GameObject[] gameObjects;
    private Transform Origin;

    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    private GameObject GetRandomSpaceship()
    {
        int randomNumber = Random.Range(0, gameObjects.Length);
        GameObject ship = gameObjects[randomNumber];
        return ship;
    }

    private void Spawn()
    {
        if(Origin == null) { return; }
        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);

        GameObject shipToSpawn = GetRandomSpaceship();

        Instantiate(shipToSpawn, SpawnPos, Quaternion.identity);
    }    
}
