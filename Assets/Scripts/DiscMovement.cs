using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DiscMovement : MonoBehaviour
{
    [SerializeField] GameObject trapSpawnPointRotateAround;

    private float randomDiscForce;

    private bool discLaunched;
    public bool discHitBool;

    private SpawnManager spawnManager;
    private GameManager gameManager;
    private UIManager uiManager;

    private AudioSource audioSource;

    private Rigidbody rb;

    private float randomTrapYRotation;
    private float randomTrapXRotation;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();

        

        audioSource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();

        trapSpawnPointRotateAround = GameObject.Find("RotateAround");

        LookAtTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (discLaunched && !discHitBool)
        {
            timer += Time.deltaTime;
            if ( timer < 2)
            rb.velocity = rb.velocity * .98f;
            else
            {
                rb.velocity = rb.velocity * .98f;
            }
        }
    }

    private void LookAtTarget()
    {
        //transform.LookAt(trapSpawnPointRotateAround.transform.position);
        LaunchDisc();
    }


    private void LaunchDisc()
    {
        //randomTrapXRotation = Random.Range(-15, -20);
        //randomTrapYRotation = Random.Range(-45, 45);

                                                //randomDiscForce = Random.Range(55 ,60 );

        randomDiscForce = Random.Range(90,110);

        //gameObject.transform.RotateAroundLocal

        //gameObject.transform.Rotate(randomTrapXRotation, randomTrapYRotation, gameObject.transform.rotation.z, Space.Self);

        //gameObject.transform.Rotate(Vector3.right, randomTrapYRotation);
        //gameObject.transform.Rotate(Vector3.up, randomTrapXRotation);

        //Vector3 launchAngle = new Vector3(0, 1, 1);

        rb.AddRelativeForce(Vector3.forward * randomDiscForce, ForceMode.Impulse);

        Debug.Log("" + randomDiscForce + " was the force added to disc # " + GameManager.trapDiscs);

        discLaunched = true;
        //Debug.Log("X Rotation: " + randomTrapXRotation + " Y Rotation: " + randomTrapYRotation + " Disc: " + GameManager.trapDiscs);

    }

    public void DiscHit()
    {
        discHitBool = true;

        GameManager.totalTrapDiscsHit++;
        GameManager.trapDiscsHitThisRound++;

        uiManager.DiscHitUI();

        CheckTrapScore();

        Destroy(gameObject, 1.2f);

    }

    public void DiscMissed()
    {
        discHitBool = true;
        rb.isKinematic = true;
        rb.useGravity = false;
        if (GameManager.trapDiscs < 25)
        {
            uiManager.DiscMissedUI();
            CheckTrapScore();
        }
        else
        {
            uiManager.DiscMissedUI();
            CheckTrapScore();
        }

        Destroy(gameObject, 1.2f);
    }

    public void CheckTrapScore()
    {
        if (GameManager.trapDiscs < 25)
        {
            if (GameManager.trapDiscs == 5)
            {
                if(GameManager.trapDiscsHitThisRound > 2)
                {
                    if(GameManager.trapDiscsHitThisRound > 3)
                    {
                        if(GameManager.trapDiscsHitThisRound > 4)
                        {
                            uiManager.PerfectTrapRound();
                        }
                        else
                        {
                            uiManager.GreatTrapRound();
                        }
                    }
                    else
                    {
                        uiManager.GoodTrapRound();
                    }
                }
                GameManager.trapShootingStation = 2;
                gameManager.StartTrapLevelMethod();
            }
            else if (GameManager.trapDiscs == 10)
            {
                if (GameManager.trapDiscsHitThisRound > 2)
                {
                    if (GameManager.trapDiscsHitThisRound > 3)
                    {
                        if (GameManager.trapDiscsHitThisRound > 4)
                        {
                            uiManager.PerfectTrapRound();
                        }
                        else
                        {
                            uiManager.GreatTrapRound();
                        }
                    }
                    else
                    {
                        uiManager.GoodTrapRound();
                    }
                }
                GameManager.trapShootingStation = 3;
                gameManager.StartTrapLevelMethod();
            }
            else if (GameManager.trapDiscs == 15)
            {
                if (GameManager.trapDiscsHitThisRound > 2)
                {
                    if (GameManager.trapDiscsHitThisRound > 3)
                    {
                        if (GameManager.trapDiscsHitThisRound > 4)
                        {
                            uiManager.PerfectTrapRound();
                        }
                        else
                        {
                            uiManager.GreatTrapRound();
                        }
                    }
                    else
                    {
                        uiManager.GoodTrapRound();
                    }
                }
                GameManager.trapShootingStation = 4;
                gameManager.StartTrapLevelMethod();
            }
            else if (GameManager.trapDiscs == 20)
            {
                if (GameManager.trapDiscsHitThisRound > 2)
                {
                    if (GameManager.trapDiscsHitThisRound > 3)
                    {
                        if (GameManager.trapDiscsHitThisRound > 4)
                        {
                            uiManager.PerfectTrapRound();
                        }
                        else
                        {
                            uiManager.GreatTrapRound();
                        }
                    }
                    else
                    {
                        uiManager.GoodTrapRound();
                    }
                }
                GameManager.trapShootingStation = 5;
                gameManager.StartTrapLevelMethod();
            }
            else
            {
                GameManager.ammo = 2;
                spawnManager.readyForTrapDisc = true;
                uiManager.ReadyForTrapDisc();
            }
        }
        else
        {
            uiManager.ShowFinalTrapMessage(GameManager.totalTrapDiscsHit);
                
        }
    }


}
