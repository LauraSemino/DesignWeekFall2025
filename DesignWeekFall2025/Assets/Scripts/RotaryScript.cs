using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotaryScript : MonoBehaviour
{
    public float pos;
    public float smoothTime;

    public Vector3 facingDir;

    public RectTransform crosshair;

    public GameObject projectile;
    public float charge;
    public Slider chargeUI;

    public Camera cam;

    public ButtonScript bs;

    public bool isBroken;
    public AudioSource chargeSound;
    public AudioClip audioClip;
    bool chargeSoundPlayed;
    float time;
    public float turnSpeed;

    // Update is called once per frame
    void Update()
    {        
        //changes facing direction of the turret for spawning bullets later
        facingDir = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z);
        facingDir.y = pos*3.6f;
        transform.rotation = Quaternion.Euler(facingDir);

        Vector3 mousePos = Input.mousePosition;
        crosshair.anchoredPosition = Vector3.MoveTowards(crosshair.anchoredPosition, mousePos, Time.deltaTime * turnSpeed);
        smoothTime = 0;

        //firing (replace with proper input when available)
        if (Input.GetMouseButton(0) && isBroken == false)
        {
            if (!chargeSoundPlayed)
            {
                chargeSound.clip = audioClip;
                chargeSound.Play();
                chargeSoundPlayed = true;
            }
            charge += 5f * Time.deltaTime;
            if(charge >= 15f)
            {
                charge = 0;
                isBroken = true;
                //do a malfunction here
            }
        }
        if (!Input.GetMouseButton(0) && isBroken == false)
        {
            chargeSoundPlayed = false;
            chargeSound.Stop();
            if (charge >= 5)
            {
                Fire();
            }
            else
            {
                charge = 0;
                //potentially do a malfunction here
            }
          
        }
        if(isBroken == true)
        {
            chargeSoundPlayed = false;
            chargeSound.Stop();
        }
        chargeUI.value = charge/15;


        //debug break
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBroken = true;
        }
    }
    private void FixedUpdate()
    {
        
    }

    void Fire()
    {
        GameObject p;
        p = Instantiate(projectile);
        p.transform.position = new Vector3 (0,2,0);
        p.GetComponent<Projectile>().speed = charge;
        p.GetComponent<Projectile>().damage = charge/5;
        charge = 0;
        p.GetComponent<Projectile>().direction = cam.ScreenPointToRay(crosshair.transform.position).direction;
        int breakChance;
        breakChance = Random.Range(0, 5);
        if (breakChance == 1)
        {
            isBroken = true;
            Debug.Log("break");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //gameover;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            SceneManager.UnloadSceneAsync("MainScene");
            Debug.Log("gameover");
        }
    }
}
