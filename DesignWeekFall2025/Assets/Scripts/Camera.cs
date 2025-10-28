using UnityEngine;
using Phidget22;
using System.Collections;
using System.Collections.Generic;

public class Camera : MonoBehaviour
{
    public Transform turret;
    public Vector3 dir;
    public float smoothTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == turret.rotation.y)
        {
            smoothTime = 0;
        }
        else
        {
            dir = new Vector3(0, Mathf.Lerp(transform.rotation.y, turret.rotation.y, smoothTime), 0);
            if(smoothTime < 1)
            {
                smoothTime += Time.deltaTime;
            }
            
        }       
        dir = dir * 115.2f;
        transform.rotation = Quaternion.Euler(dir);


    }
   
}
