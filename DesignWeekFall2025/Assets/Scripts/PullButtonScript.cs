using Phidget22;
using Phidget22.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullButtonScript : MonoBehaviour
{

    DigitalInput pullcord;
    public bool pullCordState;

    void Start()
    {
        pullcord = new DigitalInput();
        pullcord.HubPort = 0; //number on the hub
        pullcord.IsHubPortDevice = true;
        pullcord.StateChange += OnPullCordStateChange;
        pullcord.Open(1000);
    }

    private void OnPullCordStateChange(object sender, DigitalInputStateChangeEventArgs e)
    {
        pullCordState = e.State;
    }

    void Update()
    {
        //use pullCordState here!!
    }

    private void OnApplicationQuit()
    {
        pullcord.Close();
        pullcord.Dispose();
    }
}