using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
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

    [SerializeField] GameObject[] trapHitImages;
    [SerializeField] GameObject[] trapMissedImages;

    public GameObject ammoImage1;
    public GameObject ammoImage2;
    public GameObject ammoImage3;

    public GameObject trapReadyIndicator;
    public GameObject trapNotReadyIndicator;
    public GameObject trapAmmoImage1;
    public GameObject trapAmmoImage2;

    [SerializeField] TextMeshProUGUI totalDucksText;
    [SerializeField] TextMeshProUGUI totalDiscsText;

    [SerializeField] GameObject duckSigns;
    [SerializeField] GameObject round1Sign;
    [SerializeField] GameObject round2Sign;
    [SerializeField] GameObject round3Sign;

    [SerializeField] GameObject youWinImage;
    [SerializeField] GameObject youLoseImage;

    [SerializeField] GameObject trapLowScore;
    [SerializeField] GameObject trapGoodScore;
    [SerializeField] GameObject trapGreatScore;
    [SerializeField] GameObject trapAmazingScore;
    [SerializeField] GameObject trapPerfectScore;

    [SerializeField] GameObject trapGoodRound;
    [SerializeField] GameObject trapGreatRound;
    [SerializeField] GameObject trapPerfectRound;

    [SerializeField] GameObject sayPullToCallDisc;

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

        TurnOffRoundSigns();

        youWinImage.SetActive(false);
        youLoseImage.SetActive(false);

        totalDucksText.text = "0";
    }

    public void DuckHitUI(int duckNumber)
    {
        if (duckNumber == 1)
            duckImage1.SetActive(true);
        else if (duckNumber == 2)
            duckImage2.SetActive(true);
        else if (duckNumber == 3)
            duckImage3.SetActive(true);
        else if (duckNumber == 4)
            duckImage4.SetActive(true);
        else if (duckNumber == 5)
            duckImage5.SetActive(true);
        else if (duckNumber == 6)
            duckImage6.SetActive(true);
        else if (duckNumber == 7)
            duckImage7.SetActive(true);
        else if (duckNumber == 8)
            duckImage8.SetActive(true);
        else if (duckNumber == 9)
            duckImage9.SetActive(true);
        else if (duckNumber == 10)
            duckImage10.SetActive(true);


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

        TurnOffRoundSigns();

        youWinImage.SetActive(false);
        youLoseImage.SetActive(false);

        totalDucksText.text = "0";
    }

    public void DuckHuntYouLose()
    {
        youLoseImage.SetActive(true);
    }

    public void DuckHuntYouWin()
    {
        youWinImage.SetActive(true);
    }

    public void ReadyForTrapDisc()
    {
        trapAmmoImage1.SetActive(true);
        trapAmmoImage2.SetActive(true);
        trapReadyIndicator.SetActive(true);
    }

    public void DiscHitUI()
    {
        if (GameManager.trapDiscs == 1)
        {
            trapHitImages[0].SetActive(true);
            sayPullToCallDisc.SetActive(false);
        }
        else if (GameManager.trapDiscs == 2)
            trapHitImages[1].SetActive(true);
        else if (GameManager.trapDiscs == 3)
            trapHitImages[2].SetActive(true);
        else if (GameManager.trapDiscs == 4)
            trapHitImages[3].SetActive(true);
        else if (GameManager.trapDiscs == 5)
            trapHitImages[4].SetActive(true);
        else if (GameManager.trapDiscs == 6)
        {
            trapHitImages[5].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 7)
            trapHitImages[6].SetActive(true);
        else if (GameManager.trapDiscs == 8)
            trapHitImages[7].SetActive(true);
        else if (GameManager.trapDiscs == 9)
            trapHitImages[8].SetActive(true);
        else if (GameManager.trapDiscs == 10)
            trapHitImages[9].SetActive(true);
        else if (GameManager.trapDiscs == 11)
        {
            trapHitImages[10].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 12)
            trapHitImages[11].SetActive(true);
        else if (GameManager.trapDiscs == 13)
            trapHitImages[12].SetActive(true);
        else if (GameManager.trapDiscs == 14)
            trapHitImages[13].SetActive(true);
        else if (GameManager.trapDiscs == 15)
            trapHitImages[14].SetActive(true);
        else if (GameManager.trapDiscs == 16)
        {
            trapHitImages[15].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 17)
            trapHitImages[16].SetActive(true);
        else if (GameManager.trapDiscs == 18)
            trapHitImages[17].SetActive(true);
        else if (GameManager.trapDiscs == 19)
            trapHitImages[18].SetActive(true);
        else if (GameManager.trapDiscs == 20)
            trapHitImages[19].SetActive(true);
        else if (GameManager.trapDiscs == 21)
        {
            trapHitImages[20].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 22)
            trapHitImages[21].SetActive(true);
        else if (GameManager.trapDiscs == 23)
            trapHitImages[22].SetActive(true);
        else if (GameManager.trapDiscs == 24)
            trapHitImages[23].SetActive(true);
        else if (GameManager.trapDiscs == 25)
            trapHitImages[24].SetActive(true);

        totalDiscsText.text = "" + GameManager.totalTrapDiscsHit;

    }

    public void TurnOffRoundFeedback()
    {
        trapPerfectRound.SetActive(false);
        trapGoodRound.SetActive(false);
        trapGreatRound.SetActive(false);
    }

    public void DiscMissedUI()
    {
        if (GameManager.trapDiscs == 1)
        {
            trapMissedImages[0].SetActive(true);
            sayPullToCallDisc.SetActive(false);
        }
        else if (GameManager.trapDiscs == 2)
            trapMissedImages[1].SetActive(true);
        else if (GameManager.trapDiscs == 3)
            trapMissedImages[2].SetActive(true);
        else if (GameManager.trapDiscs == 4)
            trapMissedImages[3].SetActive(true);
        else if (GameManager.trapDiscs == 5)
            trapMissedImages[4].SetActive(true);
        else if (GameManager.trapDiscs == 6)
        {
            trapMissedImages[5].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 7)
            trapMissedImages[6].SetActive(true);
        else if (GameManager.trapDiscs == 8)
            trapMissedImages[7].SetActive(true);
        else if (GameManager.trapDiscs == 9)
            trapMissedImages[8].SetActive(true);
        else if (GameManager.trapDiscs == 10)
            trapMissedImages[9].SetActive(true);
        else if (GameManager.trapDiscs == 11)
        {
            trapMissedImages[10].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 12)
            trapMissedImages[11].SetActive(true);
        else if (GameManager.trapDiscs == 13)
            trapMissedImages[12].SetActive(true);
        else if (GameManager.trapDiscs == 14)
            trapMissedImages[13].SetActive(true);
        else if (GameManager.trapDiscs == 15)
            trapMissedImages[14].SetActive(true);
        else if (GameManager.trapDiscs == 16)
        {
            trapMissedImages[15].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 17)
            trapMissedImages[16].SetActive(true);
        else if (GameManager.trapDiscs == 18)
            trapMissedImages[17].SetActive(true);
        else if (GameManager.trapDiscs == 19)
            trapMissedImages[18].SetActive(true);
        else if (GameManager.trapDiscs == 20)
            trapMissedImages[19].SetActive(true);
        else if (GameManager.trapDiscs == 21)
        {
            trapMissedImages[20].SetActive(true);
            TurnOffRoundFeedback();
        }
        else if (GameManager.trapDiscs == 22)
            trapMissedImages[21].SetActive(true);
        else if (GameManager.trapDiscs == 23)
            trapMissedImages[22].SetActive(true);
        else if (GameManager.trapDiscs == 24)
            trapMissedImages[23].SetActive(true);
        else if (GameManager.trapDiscs == 25)
            trapMissedImages[24].SetActive(true);
    }

    public void ShowFinalTrapMessage(int discsHit)
    {
        if (discsHit > 9)
        {
            if (discsHit > 13)
            {
                if (discsHit > 18)
                {
                    if (discsHit > 24)
                    {
                        trapPerfectScore.SetActive(true);
                    }
                    else
                    {
                        trapAmazingScore.SetActive(true);
                    }
                }
                else
                {
                    trapGreatScore.SetActive(true);
                }

            }
            else
            {
                trapGoodScore.SetActive(true);
            }
        }
        else
        {
            trapLowScore.SetActive(true);
        }
    }

    public void GoodTrapRound()
    {
        trapGoodRound.SetActive(true);
    }
    public void GreatTrapRound()
    {
        trapGreatRound.SetActive(true);
    }
    public void PerfectTrapRound()
    {
        trapPerfectRound.SetActive(true);
    }

    public void ShowLevel1Sign()
    {
        duckSigns.SetActive(true);
        round1Sign.SetActive(true);
    }
    public void StartDuckHuntRound2()
    {
        duckSigns.SetActive(true);
        round2Sign.SetActive(true);

        StartCoroutine("DuckHuntRoundSwitch", 5f);
    }
    public void StartDuckHuntRound3()
    {
        duckSigns.SetActive(true);
        round3Sign.SetActive(true);
        StartCoroutine("DuckHuntRoundSwitch", 5f);
    }
    public void TurnOffRoundSigns()
    {
        duckSigns.SetActive(false);
        round1Sign.SetActive(false);
        round2Sign.SetActive(false);
        round3Sign.SetActive(false);
    }

    private IEnumerator DuckHuntRoundSwitch(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        GameManager.ducksHitThisRound = 0;
        spawnManager.duckNumber = 0;
        GameManager.ammo = 3;
        spawnManager.NextDuckHuntLevelMethod();
    }
    
}
