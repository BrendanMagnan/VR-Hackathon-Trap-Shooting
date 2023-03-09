using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscCollisions : MonoBehaviour
{
    private DiscMovement discMovementScript;
    private BreakFruit breakFruitScript;

    // Start is called before the first frame update
    void Start()
    {
        discMovementScript = gameObject.GetComponent<DiscMovement>();
        breakFruitScript = gameObject.GetComponent<BreakFruit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!discMovementScript.discHitBool)
            {
                Debug.Log("Disc hit by bullet");
                breakFruitScript.Run();

                discMovementScript.DiscHit();
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Disc Hit Ground");
            discMovementScript.DiscMissed();
        }

    }

}
