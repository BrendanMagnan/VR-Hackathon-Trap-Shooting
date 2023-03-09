using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SportingDiscMovement : MonoBehaviour
{

    private GameObject shotTarget1;
    private GameObject shotTarget2;
    private GameObject shotTarget3;
    private GameObject shotTarget4;
    private GameObject shotTarget5;
    private GameObject shotTarget6;
    private GameObject shotTarget7;
    private GameObject shotTarget8;

    private int randomShotTarget;

    private float randomDiscSpeed;

    private Rigidbody rb;

    void Start()
    {
        shotTarget1 = GameObject.Find("BirdFlyTarget1");
        shotTarget2 = GameObject.Find("BirdFlyTarget2");
        shotTarget3 = GameObject.Find("BirdFlyTarget3");
        shotTarget4 = GameObject.Find("BirdFlyTarget4");
        shotTarget5 = GameObject.Find("BirdFlyTarget5");
        shotTarget6 = GameObject.Find("BirdFlyTarget6");
        shotTarget7 = GameObject.Find("BirdFlyTarget7");
        shotTarget8 = GameObject.Find("BirdFlyTarget8");

        rb = gameObject.GetComponent<Rigidbody>();

        LookAtTarget();

        Debug.Log("Bird Spawned");
    }

    void Update()
    {
        if (transform.position.y < 19.9)
            MoveToTarget();
        else
            DestroyBird();
    }

    private void LookAtTarget()
    {
        randomShotTarget = Random.Range(0, 7);

        if (randomShotTarget == 0)
            transform.LookAt(shotTarget1.transform);
        else if (randomShotTarget == 1)
            transform.LookAt(shotTarget2.transform);
        else if (randomShotTarget == 2)
            transform.LookAt(shotTarget3.transform);
        else if (randomShotTarget == 3)
            transform.LookAt(shotTarget4.transform);
        else if (randomShotTarget == 4)
            transform.LookAt(shotTarget5.transform);
        else if (randomShotTarget == 5)
            transform.LookAt(shotTarget6.transform);
        else if (randomShotTarget == 6)
            transform.LookAt(shotTarget7.transform);
        else if (randomShotTarget == 7)
            transform.LookAt(shotTarget8.transform);

        randomDiscSpeed = Random.Range(100, 150);

        rb.AddForce(Vector3.forward * randomDiscSpeed, ForceMode.Impulse);

        

    }

    private void MoveToTarget()
    {
        transform.Translate(Vector3.forward * randomDiscSpeed * Time.deltaTime);
    }

    private void DestroyBird()
    {
        Destroy(gameObject, 0.0f);
        Debug.Log("Bird Destroyed");
    }

}
