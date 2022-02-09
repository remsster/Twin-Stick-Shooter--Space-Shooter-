using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool MouseLook = true;
    public string HoriAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string Fire1 = "Fire1";
    public float MaxSpeed = 5f;
    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Hori = Input.GetAxis(HoriAxis);
        float Vert = Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Hori, 0, Vert);
        rb.AddForce(MoveDirection.normalized * MaxSpeed);
        rb.velocity = new Vector3(
                Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed),
                Mathf.Clamp(rb.velocity.y, -MaxSpeed, MaxSpeed),
                Mathf.Clamp(rb.velocity.z, -MaxSpeed, MaxSpeed)
            );
        
        if (MouseLook)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            MousePosWorld = new Vector3(MousePosWorld.x, 0, MousePosWorld.z);
            Vector3 LookDirection = MousePosWorld - transform.position;
            transform.localRotation = Quaternion.LookRotation(LookDirection, Vector3.up);
        }
        
    }
}
