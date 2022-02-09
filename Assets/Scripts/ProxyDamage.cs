using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    // Damage per second
    public float DamageRate = 10f;

    private void OnTriggerStay(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();

        if (health == null) { return; }
        health.HealthPoints -= DamageRate * Time.deltaTime;
    }
}
