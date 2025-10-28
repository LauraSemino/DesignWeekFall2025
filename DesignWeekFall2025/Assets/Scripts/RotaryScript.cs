using Phidget22;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaryScript : MonoBehaviour
{
    Encoder encoder;
    public float pos;
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
    }

    private void OnApplicationQuit()
    {
        encoder.Close();
        encoder.Dispose();
    }
}
