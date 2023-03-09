using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageUI : MonoBehaviour
{
    [SerializeField] GameObject duckImage1;
    [SerializeField] GameObject duckImage2;
    [SerializeField] GameObject duckImage3;
    [SerializeField] GameObject duckImage4;
    [SerializeField] GameObject duckImage5;
    [SerializeField] GameObject duckImage6;
    [SerializeField] GameObject duckImage7;
    [SerializeField] GameObject duckImage8;
    [SerializeField] GameObject duckImage9;
    [SerializeField] GameObject duckImage10;

    [SerializeField] GameObject duckMissedImage1;
    [SerializeField] GameObject duckMissedImage2;
    [SerializeField] GameObject duckMissedImage3;
    [SerializeField] GameObject duckMissedImage4;
    [SerializeField] GameObject duckMissedImage5;
    [SerializeField] GameObject duckMissedImage6;
    [SerializeField] GameObject duckMissedImage7;
    [SerializeField] GameObject duckMissedImage8;
    [SerializeField] GameObject duckMissedImage9;
    [SerializeField] GameObject duckMissedImage10;

    public GameObject ammoImage1;
    public GameObject ammoImage2;
    public GameObject ammoImage3;

    [SerializeField] TextMeshProUGUI totalDucksText;

    private SpawnManager spawnManager;

    void Start()
    {
        totalDucksText.text = "0";
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {

    }

    public void restartDuckHunt()
    {
        duckImage1.SetActive(false);
        duckImage2.SetActive(false);
        duckImage3.SetActive(false);
        duckImage4.SetActive(false);
        duckImage5.SetActive(false);
        duckImage6.SetActive(false);
        duckImage7.SetActive(false);
        duckImage8.SetActive(false);
        duckImage9.SetActive(false);
        duckImage10.SetActive(false);

        duckMissedImage1.SetActive(false);
        duckMissedImage2.SetActive(false);
        duckMissedImage3.SetActive(false);
        duckMissedImage4.SetActive(false);
        duckMissedImage5.SetActive(false);
        duckMissedImage6.SetActive(false);
        duckMissedImage7.SetActive(false);
        duckMissedImage8.SetActive(false);
        duckMissedImage9.SetActive(false);
        duckMissedImage10.SetActive(false);

        ammoImage1.SetActive(true);
        ammoImage2.SetActive(true);
        ammoImage3.SetActive(true);

        totalDucksText.text = "0";
    }

    public void DuckHitUI(int duckNumber)
    {
        if (spawnManager.duckNumber == 1)
            duckImage1.SetActive(true);
        else if (spawnManager.duckNumber == 2)
            duckImage2.SetActive(true);
        else if (spawnManager.duckNumber == 3)
            duckImage3.SetActive(true);
        else if (spawnManager.duckNumber == 4)
            duckImage4.SetActive(true);
        else if (spawnManager.duckNumber == 5)
            duckImage5.SetActive(true);
        else if (spawnManager.duckNumber == 6)
            duckImage6.SetActive(true);
        else if (spawnManager.duckNumber == 7)
            duckImage7.SetActive(true);
        else if (spawnManager.duckNumber == 8)
            duckImage8.SetActive(true);
        else if (spawnManager.duckNumber == 9)
            duckImage9.SetActive(true);
        else if (spawnManager.duckNumber == 10)
            duckImage10.SetActive(true);

        ammoImage1.SetActive(true);
        ammoImage2.SetActive(true);
        ammoImage3.SetActive(true);


        totalDucksText.text = "" + GameManager.totalDucksHit + "";

    }

    public void DuckMissedUI(int duckNumber)
    {
        if (spawnManager.duckNumber == 1)
            duckMissedImage1.SetActive(true);
        else if (spawnManager.duckNumber == 2)
            duckMissedImage2.SetActive(true);
        else if (spawnManager.duckNumber == 3)
            duckMissedImage3.SetActive(true);
        else if (spawnManager.duckNumber == 4)
            duckMissedImage4.SetActive(true);
        else if (spawnManager.duckNumber == 5)
            duckMissedImage5.SetActive(true);
        else if (spawnManager.duckNumber == 6)
            duckMissedImage6.SetActive(true);
        else if (spawnManager.duckNumber == 7)
            duckMissedImage7.SetActive(true);
        else if (spawnManager.duckNumber == 8)
            duckMissedImage8.SetActive(true);
        else if (spawnManager.duckNumber == 9)
            duckMissedImage9.SetActive(true);
        else if (spawnManager.duckNumber == 10)
            duckMissedImage10.SetActive(true);

        ammoImage1.SetActive(true);
        ammoImage2.SetActive(true);
        ammoImage3.SetActive(true);
    }
    public void DuckHuntNextLevel()
    {
        duckImage1.SetActive(false);
        duckImage2.SetActive(false);
        duckImage3.SetActive(false);
        duckImage4.SetActive(false);
        duckImage5.SetActive(false);
        duckImage6.SetActive(false);
        duckImage7.SetActive(false);
        duckImage8.SetActive(false);
        duckImage9.SetActive(false);
        duckImage10.SetActive(false);

        duckMissedImage1.SetActive(false);
        duckMissedImage2.SetActive(false);
        duckMissedImage3.SetActive(false);
        duckMissedImage4.SetActive(false);
        duckMissedImage5.SetActive(false);
        duckMissedImage6.SetActive(false);
        duckMissedImage7.SetActive(false);
        duckMissedImage8.SetActive(false);
        duckMissedImage9.SetActive(false);
        duckMissedImage10.SetActive(false);

        ammoImage1.SetActive(true);
        ammoImage2.SetActive(true);
        ammoImage3.SetActive(true);

        spawnManager.duckNumber = 0;

    }

    public void QuitDuckHuntUI()
    {
        duckImage1.SetActive(false);
        duckImage2.SetActive(false);
        duckImage3.SetActive(false);
        duckImage4.SetActive(false);
        duckImage5.SetActive(false);
        duckImage6.SetActive(false);
        duckImage7.SetActive(false);
        duckImage8.SetActive(false);
        duckImage9.SetActive(false);
        duckImage10.SetActive(false);

        duckMissedImage1.SetActive(false);
        duckMissedImage2.SetActive(false);
        duckMissedImage3.SetActive(false);
        duckMissedImage4.SetActive(false);
        duckMissedImage5.SetActive(false);
        duckMissedImage6.SetActive(false);
        duckMissedImage7.SetActive(false);
        duckMissedImage8.SetActive(false);
        duckMissedImage9.SetActive(false);
        duckMissedImage10.SetActive(false);

        ammoImage1.SetActive(true);
        ammoImage2.SetActive(true);
        ammoImage3.SetActive(true);

        totalDucksText.text = "0";
    }
}
