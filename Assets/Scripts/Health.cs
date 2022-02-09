using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject DeathParticlesPrefab;
    public bool ShouldDestroyOnDeath = true;
    [SerializeField] private float healthPoints = 100f;


    public float HealthPoints 
    { 
        get => healthPoints;
        set 
        {
            healthPoints = value;

            if (healthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if (DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, transform.position, transform.rotation);
                }
                if (ShouldDestroyOnDeath) Destroy(gameObject);
            }
        } 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) HealthPoints = 0;
    }
}
