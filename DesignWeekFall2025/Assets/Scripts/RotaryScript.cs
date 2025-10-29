using Phidget22;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;

public class RotaryScript : MonoBehaviour
{
    Encoder encoder;
    public float pos;
    public float smoothTime;

    public Vector3 facingDir;

    public RectTransform crosshair;
    
    void Start()
    {
        encoder = new Encoder();
        encoder.Open();
        encoder.HubPort = 3;
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

    }
    private void FixedUpdate()
    {
        
    }

    private void OnApplicationQuit()
    {
        encoder.Close();
        encoder.Dispose();
    }
}
