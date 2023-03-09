using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject levelCompleteMessage;
    [SerializeField] GameObject getReadyMessage;

    [SerializeField] GameObject duckHuntBush1;
    [SerializeField] GameObject duckHuntBush2;
    [SerializeField] GameObject duckHuntBush3;
    [SerializeField] GameObject duckHuntBush4;
    [SerializeField] GameObject duckHuntBush5;

    [SerializeField] GameObject sportingBush1;
    [SerializeField] GameObject sportingBush2;
    [SerializeField] GameObject sportingBush3;
    [SerializeField] GameObject sportingBush4;
    [SerializeField] GameObject sportingBush5;
    [SerializeField] GameObject sportingBush6;
    [SerializeField] GameObject sportingBush7;
    [SerializeField] GameObject sportingBush8;

    [SerializeField] GameObject birdPrefab;

    private float randomTimeBetweenSportingDiscs;
    [SerializeField] GameObject sportingDiscPrefab;

    public int duckNumber;

    private int randomBushNumber;
    private float randomTimeBetweenBirds;
    private float randomFirstBirdWaitTime;
    [SerializeField] GameObject trapSpawnPoint;
    [SerializeField] GameObject trapRotateAround;
    [SerializeField] GameObject trapSpawnPointReset;

    public bool readyForTrapDisc;
    private float randomTrapDiscWaitTime;
    private float randomTrapYRotation;
    private float randomTrapXRotation;

    private UIManager uiManager;
    private GameManager gameManager;

    

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    private void Update()
    {
        
    }

    private IEnumerator SpawnDuck(float timeToWait)
    {
        

        yield return new WaitForSeconds(timeToWait * 3);


        uiManager.ammoImage1.SetActive(true);
        uiManager.ammoImage2.SetActive(true);
        uiManager.ammoImage3.SetActive(true);

        GameManager.ammo = 3;
        randomBushNumber = Random.Range(0, 5);

        if (randomBushNumber == 0)
            Instantiate(birdPrefab, duckHuntBush1.transform.position, birdPrefab.transform.rotation);
        else if (randomBushNumber == 1)
            Instantiate(birdPrefab, duckHuntBush2.transform.position, birdPrefab.transform.rotation);
        else if (randomBushNumber == 2)
            Instantiate(birdPrefab, duckHuntBush3.transform.position, birdPrefab.transform.rotation);
        else if (randomBushNumber == 3)
            Instantiate(birdPrefab, duckHuntBush4.transform.position, birdPrefab.transform.rotation);
        else if (randomBushNumber == 4)
            Instantiate(birdPrefab, duckHuntBush5.transform.position, birdPrefab.transform.rotation);

        duckNumber++;
    
    }
    
    private IEnumerator NextDuckHuntLevel(float timeToWait)
    {
        //show a level complete UI thing, reset all UI elements, etc.
        levelCompleteMessage.SetActive(true);
        uiManager.DuckHuntNextLevel();
        yield return new WaitForSeconds(timeToWait * 3) ;

        levelCompleteMessage.SetActive(false);
        getReadyMessage.SetActive(true);

        yield return new WaitForSeconds(timeToWait * 3);

        getReadyMessage.SetActive(false);

        SpawnDuckMethod();
    }

    private IEnumerator SpawnSporting(float timeToWait)
    {
        randomTimeBetweenSportingDiscs = Random.Range(5.0f, 12f);

        yield return new WaitForSeconds(timeToWait * randomTimeBetweenSportingDiscs);

        randomBushNumber = Random.Range(0, 7);

        if (randomBushNumber == 0)
            Instantiate(sportingDiscPrefab, sportingBush1.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 1)
            Instantiate(sportingDiscPrefab, sportingBush2.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 2)
            Instantiate(sportingDiscPrefab, sportingBush3.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 3)
            Instantiate(sportingDiscPrefab, sportingBush4.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 4)
            Instantiate(sportingDiscPrefab, sportingBush5.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 5)
            Instantiate(sportingDiscPrefab, sportingBush6.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 6)
            Instantiate(sportingDiscPrefab, sportingBush7.transform.position, sportingDiscPrefab.transform.rotation);
        else if (randomBushNumber == 7)
            Instantiate(sportingDiscPrefab, sportingBush8.transform.position, sportingDiscPrefab.transform.rotation);


    }

    public void StartTrapMode()
    {
        GameManager.trapShootingStation = 1;

        readyForTrapDisc = true;
    }


    public void SpawnTrapDiscMethod()
    {
        StartCoroutine("SpawnTrapDisc", 1.0f);
    }
    public void StartDuckHuntMode()
    {
        GameManager.ammo = 3;
        SpawnDuckMethod();
    }

    public void SpawnDuckMethod()
    {
        StartCoroutine("SpawnDuck", 1.0f);
    }
    public void NextDuckHuntLevelMethod()
    {
        StartCoroutine("NextDuckHuntLevel", 1.0f);
    }

    public void TrapVoiceInput()
    {
        if (readyForTrapDisc)
            SpawnTrapDiscMethod();
    }

    private IEnumerator SpawnTrapDisc(float timeToWait)
    {

        trapSpawnPoint.transform.rotation = trapSpawnPointReset.transform.rotation;
        trapSpawnPoint.transform.position = trapSpawnPointReset.transform.position;
        readyForTrapDisc = false;
        GameManager.ammo = 2;
        uiManager.ReadyForTrapDisc();

        //randomTrapXRotation = Random.Range(-20, -30);
        //randomTrapYRotation = Random.Range(-45, 45);

        //Vector3 diagonal = new Vector3(1 * randomTrapXRotation, 1 * randomTrapYRotation, 0);

        //trapSpawnPoint.transform.RotateAround(trapRotateAround.transform.position, diagonal, 1);
        //trapSpawnPoint.transform.RotateAround(trapRotateAround.transform.position, Vector3.up, randomTrapYRotation);
        //trapSpawnPoint.transform.RotateAround(trapRotateAround.transform.position, Vector3.right, randomTrapXRotation);

        randomTrapDiscWaitTime = Random.Range(0, 3);
        //ready for disc ui indicator = false

        yield return new WaitForSeconds(timeToWait * randomTrapDiscWaitTime);

        Instantiate(sportingDiscPrefab, trapSpawnPoint.transform.position, trapSpawnPoint.transform.rotation);
        //Debug.Log("X rotation: " + randomTrapXRotation + "/ Y Rotation: " + randomTrapYRotation);
        GameManager.trapDiscs++;

    }

    

}
