using Phidget22;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnyThing : MonoBehaviour
{
    VoltageRatioInput turny = new VoltageRatioInput();
    public float output;

    // Start is called before the first frame update
    void Start()
    {
        turny = new VoltageRatioInput();
        turny.HubPort = 2;
        turny.IsHubPortDevice = true;
        turny.Open(1000);
    }

    // Update is called once per frame
    void Update()
    {
        output = map((float)turny.VoltageRatio, 0, 1, 1, 100);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">variable to map</param>
    /// <param name="min1">value's min</param>
    /// <param name="max1">value's max</param>
    /// <param name="min2">new min</param>
    /// <param name="max2">new max</param>
    /// <returns></returns>
    float map(float value, float min1, float max1, float min2, float max2)
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
    }

    private void OnApplicationQuit()
    {
        turny.Close();
        turny.Dispose();
    }
}
