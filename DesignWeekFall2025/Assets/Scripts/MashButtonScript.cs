using Phidget22;
using Phidget22.Events;
using UnityEngine;

public class MashButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    DigitalInput button;
    public bool buttonState;

    void Start()
    {
        button = new DigitalInput();
        button.HubPort = 2; //number on the hub
        button.IsHubPortDevice = true;
        button.StateChange += OnPullCordStateChange;
        button.Open(1000);
    }

    private void OnPullCordStateChange(object sender, DigitalInputStateChangeEventArgs e)
    {
        buttonState = e.State;
    }

    void Update()
    {
        //use pullCordState here!!
    }

    private void OnApplicationQuit()
    {
        button.Close();
        button.Dispose();
    }
}
