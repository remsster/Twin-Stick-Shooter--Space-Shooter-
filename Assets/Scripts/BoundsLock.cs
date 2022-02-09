using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{
    public Rect levelBounds;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, levelBounds.xMax, levelBounds.xMin),
                transform.position.y,
                Mathf.Clamp(transform.position.z, levelBounds.yMin, levelBounds.yMax)
            );
    }

    private void OnDrawGizmosSelected()
    {
        const int cubeDepth = 1;
        Vector3 boundsCenter = new Vector3(levelBounds.xMin + levelBounds.width * .5f, 0, levelBounds.yMin + levelBounds.height * .5f);
        Vector3 boundsHeight = new Vector3(levelBounds.width, cubeDepth, levelBounds.height);
        Gizmos.DrawWireCube(boundsCenter, boundsHeight);
    }
}
