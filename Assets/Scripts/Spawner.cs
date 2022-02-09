using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 5f;
    public GameObject ObjToSpawn;
    private Transform Origin;

    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    private void Spawn()
    {
        if(Origin == null) { return; }
        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }    
}