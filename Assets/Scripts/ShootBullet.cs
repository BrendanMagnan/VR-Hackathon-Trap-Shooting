using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootBullet : MonoBehaviour
{
    public float pistolBulletSpeed = 45;
    public GameObject pistolBullet;
    public Transform muzzle;

    /*shotgun blast will have one birdshot BB out in front, followed by three layers 
     * of 4 more BBs which will travel slowly outward, creating scattershot effect. 
     * */

    public GameObject birdshotLeader;
    public GameObject birdshotLayer2;
    public GameObject birdshotLayer3;

    private float birdshotLeaderSpeed;
    private float birdshotLayer2Speed1;
    private float birdshotLayer2Speed2;
    private float birdshotLayer2Speed3;
    private float birdshotLayer2Speed4;
    private float birdshotLayer3Speed1;
    private float birdshotLayer3Speed2;
    private float birdshotLayer3Speed3;
    private float birdshotLayer3Speed4;
    private float birdshotLayer4Speed1;
    private float birdshotLayer4Speed2;
    private float birdshotLayer4Speed3;
    private float birdshotLayer4Speed4;

    public Transform birdshotSpawnPoint1;
    public Transform birdshotSpawnPoint2;
    public Transform birdshotSpawnPoint3;
    public Transform birdshotSpawnPoint4;
    public Transform birdshotSpawnPoint5;
    public Transform birdshotSpawnPoint6;
    public Transform birdshotSpawnPoint7;
    public Transform birdshotSpawnPoint8;
    public Transform birdshotSpawnPoint9;
    public Transform birdshotSpawnPoint10;
    public Transform birdshotSpawnPoint11;
    public Transform birdshotSpawnPoint12;
    public Transform birdshotSpawnPoint13;

    [SerializeField] XRDirectInteractor leftHandController;
    [SerializeField] XRDirectInteractor rightHandController;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip outOfAmmo;

    private GameManager gameManager;
    private UIManager uiManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    public void FirePistolBullet()
    {
        GameObject spawnedBullet = Instantiate(pistolBullet, muzzle.position, muzzle.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = pistolBulletSpeed * muzzle.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2.2f);
    }

    public void FireShotgun()
    {
        Debug.Log("shotgun fired");

        if (GameManager.ammo > 0)
        {
                birdshotLeaderSpeed = Random.Range(300, 350);
                birdshotLayer2Speed1 = Random.Range(285, 299);
                birdshotLayer2Speed2 = Random.Range(285, 299);
                birdshotLayer2Speed3 = Random.Range(285, 299);
                birdshotLayer2Speed4 = Random.Range(285, 299);
                birdshotLayer3Speed1 = Random.Range(270, 284);
                birdshotLayer3Speed2 = Random.Range(270, 284);
                birdshotLayer3Speed3 = Random.Range(270, 284);
                birdshotLayer3Speed4 = Random.Range(270, 284);
                birdshotLayer4Speed1 = Random.Range(255, 269);
                birdshotLayer4Speed2 = Random.Range(255, 269);
                birdshotLayer4Speed3 = Random.Range(255, 269);
                birdshotLayer4Speed4 = Random.Range(255, 269);

            GameObject spawnedBuckshot1 = Instantiate(birdshotLeader, birdshotSpawnPoint1.position, muzzle.rotation);
            spawnedBuckshot1.GetComponent<Rigidbody>().velocity = birdshotLeaderSpeed * birdshotSpawnPoint1.forward;

            GameObject spawnedBuckshot2 = Instantiate(birdshotLayer2, birdshotSpawnPoint2.transform.position, birdshotSpawnPoint2.rotation);
            spawnedBuckshot2.GetComponent<Rigidbody>().velocity = birdshotLayer2Speed1 * birdshotSpawnPoint2.forward;

            GameObject spawnedBuckshot3 = Instantiate(birdshotLayer2, birdshotSpawnPoint3.transform.position, birdshotSpawnPoint3.rotation);
            spawnedBuckshot3.GetComponent<Rigidbody>().velocity = birdshotLayer2Speed2 * birdshotSpawnPoint3.forward;

            GameObject spawnedBuckshot4 = Instantiate(birdshotLayer2, birdshotSpawnPoint4.transform.position, birdshotSpawnPoint4.rotation);
            spawnedBuckshot4.GetComponent<Rigidbody>().velocity = birdshotLayer2Speed3 * birdshotSpawnPoint4.forward;

            GameObject spawnedBuckshot5 = Instantiate(birdshotLayer2, birdshotSpawnPoint5.transform.position, birdshotSpawnPoint5.rotation);
            spawnedBuckshot5.GetComponent<Rigidbody>().velocity = birdshotLayer2Speed4 * birdshotSpawnPoint5.forward;

            GameObject spawnedBuckshot6 = Instantiate(birdshotLayer2, birdshotSpawnPoint6.transform.position, birdshotSpawnPoint6.rotation);
            spawnedBuckshot6.GetComponent<Rigidbody>().velocity = birdshotLayer3Speed1 * birdshotSpawnPoint6.forward;

            GameObject spawnedBuckshot7 = Instantiate(birdshotLayer2, birdshotSpawnPoint7.transform.position, birdshotSpawnPoint7.rotation);
            spawnedBuckshot7.GetComponent<Rigidbody>().velocity = birdshotLayer3Speed2 * birdshotSpawnPoint7.forward;

            GameObject spawnedBuckshot8 = Instantiate(birdshotLayer2, birdshotSpawnPoint8.transform.position, birdshotSpawnPoint8.rotation);
            spawnedBuckshot8.GetComponent<Rigidbody>().velocity = birdshotLayer3Speed3 * birdshotSpawnPoint8.forward;

            GameObject spawnedBuckshot9 = Instantiate(birdshotLayer2, birdshotSpawnPoint9.transform.position, birdshotSpawnPoint9.rotation);
            spawnedBuckshot9.GetComponent<Rigidbody>().velocity = birdshotLayer3Speed4 * birdshotSpawnPoint9.forward;

            GameObject spawnedBuckshot10 = Instantiate(birdshotLayer2, birdshotSpawnPoint10.transform.position, birdshotSpawnPoint10.rotation);
            spawnedBuckshot10.GetComponent<Rigidbody>().velocity = birdshotLayer4Speed1 * birdshotSpawnPoint10.forward; 

            GameObject spawnedBuckshot11 = Instantiate(birdshotLayer2, birdshotSpawnPoint11.transform.position, birdshotSpawnPoint11.rotation);
            spawnedBuckshot11.GetComponent<Rigidbody>().velocity = birdshotLayer4Speed2 * birdshotSpawnPoint11.forward; 

            GameObject spawnedBuckshot12 = Instantiate(birdshotLayer2, birdshotSpawnPoint12.transform.position, birdshotSpawnPoint12.rotation);
            spawnedBuckshot12.GetComponent<Rigidbody>().velocity = birdshotLayer4Speed3 * birdshotSpawnPoint12.forward; 

            GameObject spawnedBuckshot13 = Instantiate(birdshotLayer2, birdshotSpawnPoint13.transform.position, birdshotSpawnPoint13.rotation);
            spawnedBuckshot13.GetComponent<Rigidbody>().velocity = birdshotLayer4Speed4 * birdshotSpawnPoint13.forward;

            audioSource.PlayOneShot(audioClip);
            rightHandController.SendHapticImpulse(.3f, .15f);
            leftHandController.SendHapticImpulse(.8f, .15f);
            GameManager.ammo--;

            if (GameManager.ammo == 2) {
                uiManager.ammoImage3.SetActive(false);
            }
            else if (GameManager.ammo == 1)
            {
                uiManager.ammoImage2.SetActive(false);
                uiManager.trapAmmoImage2.SetActive(false);
            }
            else if (GameManager.ammo == 0)
            {
                uiManager.ammoImage1.SetActive(false);
                uiManager.trapAmmoImage1.SetActive(false);
            }


            Destroy(spawnedBuckshot1, 1.5f);
            Destroy(spawnedBuckshot2, 1.5f);
            Destroy(spawnedBuckshot3, 1.5f);
            Destroy(spawnedBuckshot4, 1.5f);
            Destroy(spawnedBuckshot5, 1.5f);
            Destroy(spawnedBuckshot6, 1.5f);
            Destroy(spawnedBuckshot7, 1.5f);
            Destroy(spawnedBuckshot8, 1.5f);
            Destroy(spawnedBuckshot9, 1.5f);
        }
        else
        {
            audioSource.PlayOneShot(outOfAmmo);
        }

    }
}
