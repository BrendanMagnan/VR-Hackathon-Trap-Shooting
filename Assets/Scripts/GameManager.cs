using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool playingDuckHunt;
    public static bool playingTrapMode;

    public static int trapDiscs;
    public static int totalTrapDiscsHit;
    public static int trapShootingStation;
    public static int trapDiscsHitThisRound;

    public static int ammo;
    public static int duckHuntLevel;
    public static int ducksHitThisRound;
    public static int totalDucksHit;

    [SerializeField] GameObject duckHuntObjects;
    [SerializeField] GameObject duckHuntUI;

    [SerializeField] GameObject skeetObjects;
    [SerializeField] GameObject skeetUI;

    [SerializeField] GameObject trapObjects;
    [SerializeField] GameObject trapUI;
    [SerializeField] GameObject shootingStation2Transform;
    [SerializeField] GameObject shootingStation3Transform;
    [SerializeField] GameObject shootingStation4Transform;
    [SerializeField] GameObject shootingStation5Transform;

    [SerializeField] GameObject sportingObjects;
    [SerializeField] GameObject sportingUI;

    private UIManager uiManager;
    private SpawnManager spawnManager;
    private FadeScreen screenFader;

    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject mainImage;
    [SerializeField] GameObject settingsImage;
    [SerializeField] GameObject instructionSelectImage;
    [SerializeField] GameObject duckHuntInstructions;
    [SerializeField] GameObject trapInstructions;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        screenFader = GameObject.Find("ScreenFader").GetComponent<FadeScreen>();

    }

    void Update()
    {
        
    }

    public void StartGame(int gameToStart)
    {
        if (gameToStart == 0)
        {
            //start skeet
            mainMenuCanvas.SetActive(false);
            Debug.Log("Started skeet mode");
        }
        else if (gameToStart == 1)
        {
            //start trap
            playingTrapMode = true;
            StartCoroutine("StartTrapMode", 1.0f);
            Debug.Log("Started trap mode");
        }
        else if (gameToStart == 2)
        {
            //start sporting clays
            mainMenuCanvas.SetActive(false);
            StartCoroutine("StartSportingMode", 1.0f);

            Debug.Log("Started sporting clays mode");
        }
        else
        {
            //start duck hunt mode
            playingDuckHunt = true;
            StartCoroutine("StartDuckHunt", 1.0f);

            Debug.Log("Started duck hunt mode");
        }
    }

    private IEnumerator StartTrapMode(float timeToWait)
    {
        screenFader.FadeOut();

        yield return new WaitForSeconds(timeToWait * 2);

        mainMenuCanvas.SetActive(false);
        trapObjects.SetActive(true);
        trapUI.SetActive(true);
        
        yield return new WaitForSeconds(timeToWait/4);

        screenFader.FadeIn();

        yield return new WaitForSeconds(timeToWait * 2);

        spawnManager.StartTrapMode();
    }

    public void StartTrapLevelMethod()
    {
        StartCoroutine(StartTrapLevel(1f, GameManager.trapShootingStation));
    }
    public IEnumerator StartTrapLevel(float timeToWait, int level)
    {

        yield return new WaitForSeconds(timeToWait * 2);

        screenFader.FadeOut();

        yield return new WaitForSeconds(timeToWait * 2);

        if(level == 2)
        trapObjects.transform.position = shootingStation2Transform.transform.position; 
        else if (level == 3)
            trapObjects.transform.position = shootingStation3Transform.transform.position;
        else if(level == 4)
            trapObjects.transform.position = shootingStation4Transform.transform.position;
        else if(level == 5)
            trapObjects.transform.position = shootingStation5Transform.transform.position;

        yield return new WaitForSeconds(timeToWait / 4);

        screenFader.FadeIn();

        yield return new WaitForSeconds(timeToWait * 4);

        GameManager.ammo = 2;
        uiManager.TurnOffRoundFeedback();
        uiManager.ReadyForTrapDisc();
        spawnManager.readyForTrapDisc = true;

    }
    /*
    public IEnumerator StartTrapLevel3(float timeToWait)
    {

    }
    public IEnumerator StartTrapLevel4(float timeToWait)
    {

    }
    public IEnumerator StartTrapLevel5(float timeToWait)
    {

    }
    */
    private IEnumerator StartDuckHunt(float timeToWait)
    {
        

        screenFader.FadeOut();

        yield return new WaitForSeconds(timeToWait * 2);
        mainMenuCanvas.SetActive(false);
        duckHuntObjects.SetActive(true);
        duckHuntUI.SetActive(true);

        yield return new WaitForSeconds(timeToWait/4);

        screenFader.FadeIn();

        yield return new WaitForSeconds(timeToWait * 4);

        // play ready / horn blow sfx etc.
        uiManager.ShowLevel1Sign();

        yield return new WaitForSeconds(timeToWait * 5);

        spawnManager.StartDuckHuntMode();
        uiManager.TurnOffRoundSigns();

    }

    private IEnumerator StartSportingMode(float timeToWait)
    {
        screenFader.FadeOut();

        yield return new WaitForSeconds(timeToWait * 2);

        sportingObjects.SetActive(true);
        sportingUI.SetActive(true);

        yield return new WaitForSeconds(timeToWait/4);

        screenFader.FadeIn();
    }

    public void BackToLobby()
    {
        StartCoroutine("GoBackToLobby", 1f);
    }

    private IEnumerator GoBackToLobby(float timeToWait)
    {
        screenFader.FadeOut();
        yield return new WaitForSeconds(timeToWait * 2);

        duckHuntObjects.SetActive(false);
        sportingObjects.SetActive(false);
        trapObjects.SetActive(false);
        skeetObjects.SetActive(false);

        duckHuntUI.SetActive(false);
        trapUI.SetActive(false);

        mainMenuCanvas.SetActive(true);
        GameManager.trapDiscs = 0;
        GameManager.duckHuntLevel = 0;
        GameManager.trapDiscsHitThisRound = 0;
        GameManager.ammo = 0;
        GameManager.ducksHitThisRound = 0;
        GameManager.totalDucksHit = 0;
        GameManager.playingDuckHunt = false;
        GameManager.playingTrapMode = false;
        GameManager.trapShootingStation = 1;
        GameManager.totalTrapDiscsHit = 0;

        yield return new WaitForSeconds(timeToWait /4);
        screenFader.FadeIn();
        yield return new WaitForSeconds(timeToWait * 2);
    }

    public void RestartDuckHunt()
    {
        StartCoroutine("RestartDuckHuntCoroutine", 1.0f);

    }

    private IEnumerator RestartDuckHuntCoroutine(float timeToWait)
    {
        screenFader.FadeOut();
        yield return new WaitForSeconds(timeToWait * 2);

        duckHuntLevel = 0;
        ducksHitThisRound = 0;
        spawnManager.duckNumber = 0;
        GameManager.ammo = 3;

        uiManager.restartDuckHunt();
        yield return new WaitForSeconds(timeToWait /4);

        screenFader.FadeIn();

        yield return new WaitForSeconds(timeToWait * 3);

        // play ready / horn blow sfx etc.
        uiManager.ShowLevel1Sign();

        yield return new WaitForSeconds(timeToWait * 5);

        spawnManager.StartDuckHuntMode();

    }

    public void DuckHuntNextLevel()
    {         
        spawnManager.duckNumber = 0;
    }
    
    private void QuitDuckHunt()
    {
        StartCoroutine("QuitGameDH", 1.0f);
    }

    private IEnumerator QuitGameDH(float timeToWait)
    {
        screenFader.FadeOut();
        yield return new WaitForSeconds(timeToWait * 2);

        duckHuntLevel = 0;
        ducksHitThisRound = 0;
        spawnManager.duckNumber = 0;
        GameManager.ammo = 3;
        
        uiManager.QuitDuckHuntUI();
        duckHuntObjects.SetActive(false);
        duckHuntUI.SetActive(false);
        mainMenuCanvas.SetActive(true);

        yield return new WaitForSeconds(timeToWait / 4);

        screenFader.FadeIn();
    }

    public void ShowSettings()
    {
        mainImage.SetActive(false);
        settingsImage.SetActive(true);
    }
    public void HideSettings()
    {
        settingsImage.SetActive(false);
        mainImage.SetActive(true);
    }
    public void ShowInstructions()
    {
        mainImage.SetActive(false);
        instructionSelectImage.SetActive(true);
    }
    public void HideInstructions()
    {
        instructionSelectImage.SetActive(false);
        trapInstructions.SetActive(false);
        duckHuntInstructions.SetActive(false);
        mainImage.SetActive(true);
    }
    public void BackToInstructions()
    {
        duckHuntInstructions.SetActive(false);
        trapInstructions.SetActive(false);
        instructionSelectImage.SetActive(true);
    }
    public void ShowTrapInstructions()
    {
        instructionSelectImage.SetActive(false);
        trapInstructions.SetActive(true);
    }
    public void ShowDuckHuntInstructions()
    {
        instructionSelectImage.SetActive(false);
        duckHuntInstructions.SetActive(true);
    }

}
