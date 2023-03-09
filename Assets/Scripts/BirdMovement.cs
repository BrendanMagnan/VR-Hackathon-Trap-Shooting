using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
    private GameObject flyTarget1;
    private GameObject flyTarget2;
    private GameObject flyTarget3;
    private GameObject flyTarget4;
    private GameObject flyTarget5;
    private GameObject flyTarget6;
    private GameObject flyTarget7;
    private GameObject flyTarget8;
    private GameObject flyTarget9;

    private int randomFlyTarget;

    private float randomBirdSpeed;
    public bool birdHitBool;

    private SpawnManager spawnManager;
    private GameManager gameManager;
    private UIManager uiManager;

    public Animator anim;
    public AudioSource audioSource;
    [SerializeField] AudioClip duckSpawnClip;

    void Start()
    {
        flyTarget1 = GameObject.Find("BirdFlyTarget1");
        flyTarget2 = GameObject.Find("BirdFlyTarget2");
        flyTarget3 = GameObject.Find("BirdFlyTarget3");
        flyTarget4 = GameObject.Find("BirdFlyTarget4");
        flyTarget5 = GameObject.Find("BirdFlyTarget5");
        flyTarget6 = GameObject.Find("BirdFlyTarget6");
        flyTarget7 = GameObject.Find("BirdFlyTarget7");
        flyTarget8 = GameObject.Find("BirdFlyTarget8");
        flyTarget9 = GameObject.Find("BirdFlyTarget9");

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();

        anim = gameObject.GetComponent<Animator>();

        LookAtTarget();

        Debug.Log("Bird Spawned");
    }

    void Update()
    {
        if(!birdHitBool)
            MoveToTarget();
    }

    private void LookAtTarget()
    {
        randomFlyTarget = Random.Range(0, 9);

        if (randomFlyTarget == 0)
            transform.LookAt(flyTarget1.transform);
        else if (randomFlyTarget == 1)
            transform.LookAt(flyTarget2.transform);
        else if (randomFlyTarget == 2)
            transform.LookAt(flyTarget3.transform);
        else if (randomFlyTarget == 3)
            transform.LookAt(flyTarget4.transform);
        else if (randomFlyTarget == 4)
            transform.LookAt(flyTarget5.transform);
        else if (randomFlyTarget == 5)
            transform.LookAt(flyTarget6.transform);
        else if (randomFlyTarget == 6)
            transform.LookAt(flyTarget7.transform);
        else if (randomFlyTarget == 7)
            transform.LookAt(flyTarget8.transform);
        else if (randomFlyTarget == 8)
            transform.LookAt(flyTarget9.transform);

        if(GameManager.duckHuntLevel == 0)
            randomBirdSpeed = Random.Range(6, 8);
        else if (GameManager.duckHuntLevel == 1)
        {
            randomBirdSpeed = Random.Range(8, 10);
        }
        else if (GameManager.duckHuntLevel == 2)
        {
            randomBirdSpeed = Random.Range(10,12);
        }
        


    }

    private void MoveToTarget()
    {
        transform.Translate(Vector3.forward * randomBirdSpeed * Time.deltaTime);
    }

    public void DestroyMissedBird()
    {

        if (spawnManager.duckNumber < 10)
        {
            uiManager.DuckMissedUI(spawnManager.duckNumber);
            spawnManager.SpawnDuckMethod();
        }
        else
        {
            uiManager.DuckMissedUI(spawnManager.duckNumber);
            CheckDuckHuntScore();
        }

        Destroy(gameObject, 0.1f);
        Debug.Log("Bird Missed");
    }

    public void BirdHit()
    {
        birdHitBool = true;

        //activate ragdoll mode / allow object to fall
        //play 'hit' animation
        anim.SetTrigger("Hit");

        GameManager.ducksHitThisRound++;
        GameManager.totalDucksHit++;

        uiManager.DuckHitUI(spawnManager.duckNumber);

        CheckDuckHuntScore();

        Destroy(gameObject, 2.5f);

        Debug.Log("Bird Hit");
    }

    public void CheckDuckHuntScore()
    {


        if (spawnManager.duckNumber < 10)
        {
            
            spawnManager.SpawnDuckMethod();
            
        }
        else
        {

            if (GameManager.ducksHitThisRound > 4)
            {
                if (GameManager.duckHuntLevel < 2)
                {
                    GameManager.duckHuntLevel++;
                    if(GameManager.duckHuntLevel == 1)
                    {
                        uiManager.StartDuckHuntRound2();
                    }
                    else if (GameManager.duckHuntLevel == 2)
                    {
                        uiManager.StartDuckHuntRound3();
                    }

                }
                else
                {
                    uiManager.DuckHuntYouWin();
                }
            }
            else
            {
                uiManager.DuckHuntYouLose();
            }
        }
    }

}
