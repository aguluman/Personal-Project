using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ParticleSystem explosionParticle;
   
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position + Vector3.up, explosionParticle.transform.rotation);
            
        }
    }

    
}
