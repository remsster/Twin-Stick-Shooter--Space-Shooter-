using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager AmmoManagerSingelton = null;

    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();
    private GameObject[] AmmoArray;

    private void Awake()
    {
        if (AmmoManagerSingelton != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }

        AmmoManagerSingelton = this;
        AmmoArray = new GameObject[PoolSize];

        for (int i = 0; i < PoolSize; ++i)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform ObjTransform = AmmoArray[i].transform;
            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 position, Quaternion rotation)
    {
        Transform SpawnedAmmo = AmmoManagerSingelton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = position;
        SpawnedAmmo.localRotation = rotation;
        AmmoManagerSingelton.AmmoQueue.Enqueue(SpawnedAmmo);
        return SpawnedAmmo;
    }
}
