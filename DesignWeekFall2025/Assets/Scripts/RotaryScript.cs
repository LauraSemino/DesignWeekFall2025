using Phidget22;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotaryScript : MonoBehaviour
{
    Encoder encoder;
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
    void Start()
    {
        encoder = new Encoder();
        encoder.Open();
        encoder.HubPort = 3;

        //cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {        
        //changes facing direction of the turret for spawning bullets later
        pos = encoder.Position;
        facingDir = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z);
        facingDir.y = pos*3.6f;
        transform.rotation = Quaternion.Euler(facingDir);

        //modifies the crosshair position
        Vector3 cpos;
        cpos = new Vector3(pos * 32,0,0);
        if(crosshair.anchoredPosition.x != cpos.x && smoothTime < 1)
        {
            smoothTime += 10 * Time.deltaTime;
        }
        if (smoothTime > 1)
        {
            smoothTime = 1;
        }
        crosshair.anchoredPosition = new Vector3(Mathf.Lerp(crosshair.anchoredPosition.x, cpos.x, smoothTime), 0, 0);
        smoothTime = 0;

        //clamps the distance of the crosshair
        if (crosshair.anchoredPosition.x > 512)
        {
            crosshair.anchoredPosition = new Vector3 (512,0,0);
        }
        if (crosshair.anchoredPosition.x < -512)
        {
            crosshair.anchoredPosition = new Vector3(-512, 0, 0);
        }


        //firing (replace with proper input when available)
        if (bs.pullCordState == true && isBroken == false)
        {
            charge += 5f * Time.deltaTime;
            if(charge >= 15f)
            {
                charge = 0;
                isBroken = true;
                //do a malfunction here
            }
        }
        if (bs.pullCordState == false && isBroken == false)
        {
            if(charge >= 5)
            {
                Fire();
            }
            else
            {
                charge = 0;
                
                //potentially do a malfunction here
            }
          
        }
        chargeUI.value = charge/15;


        //debug break
      /*  if (Input.GetKeyDown(KeyCode.B))
        {
            isBroken = true;
        }*/
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

    private void OnApplicationQuit()
    {
        encoder.Close();
        encoder.Dispose();
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
