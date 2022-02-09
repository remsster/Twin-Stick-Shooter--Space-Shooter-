using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    // follows the player
    public Transform ObjToFollow;
    public bool FollowPlayer = true;

    private void Awake()
    {
        if (!FollowPlayer) { return; }
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            ObjToFollow = playerObj.transform;
        }
    }

    private void Update()
    {
        if (ObjToFollow == null) { return; }
        Vector3 DirToObject = ObjToFollow.position - transform.position;
        if (DirToObject != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(DirToObject, Vector3.up);
        }


    }
}
