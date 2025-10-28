using Phidget22;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaryScript : MonoBehaviour
{
    Encoder encoder;
    public float pos;
    public Vector3 facingDir;
    void Start()
    {
        encoder = new Encoder();
        encoder.Open();
        encoder.HubPort = 3;
    }

    // Update is called once per frame
    void Update()
    {
        pos = encoder.Position;
        facingDir = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z);

        facingDir.y = pos;
       
        transform.rotation = Quaternion.Euler(facingDir);
    }

    private void OnApplicationQuit()
    {
        encoder.Close();
        encoder.Dispose();
    }
}
