using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollisions : MonoBehaviour
{

    private BirdMovement birdMovementScript;

    private ParticleSystem bulletParticle;

    // Start is called before the first frame update
    void Start()
    {
        birdMovementScript = gameObject.GetComponent<BirdMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!birdMovementScript.birdHitBool)
            {
                Debug.Log("collided with bullet");
                bulletParticle = collision.gameObject.GetComponentInChildren<ParticleSystem>();
                birdMovementScript.BirdHit(bulletParticle);
            }
            Destroy(collision.gameObject, 1.0f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MissedDuck"))
        {
            Debug.Log("missed duck");
            birdMovementScript.DestroyMissedBird();
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
           //birdMovementScript.BirdHit();

        }
    }

}
