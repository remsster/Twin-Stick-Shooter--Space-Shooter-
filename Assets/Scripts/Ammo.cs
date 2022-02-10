using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float Damage = 100f;
    public float LifeTime = 2f;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();
        if(H == null) { return; }
        H.HealthPoints -= Damage;
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
