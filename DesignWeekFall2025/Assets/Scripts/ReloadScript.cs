using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{
    public bool isBroken;
    public bool isReload;
    public TextMeshProUGUI warningText;
    public int repairType;
    public string[] strings;
    float time;
    public float reloadingTime;
    int ExNum;


    public MashButtonScript mb;
    public float mashVal;
    bool isPressed;

    public PullButtonScript pb;
    bool start;

    public Color lblue;
    public Color dblue;
    float tc;
    //  public TurnyThing tt;

    //crank fix
    // public bool check1 = false;
    //  public bool check2 = false;

    /*
    public Slider chargeUI;
    float charge;
    float shootDistance;
    */

    public RotaryScript rs;

    void Start()
    {
        //isBroken = true;
        //Repair();
        mashVal = 0;
        start = true;
        warningText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        isBroken = rs.isBroken;
        
         if (isBroken)
        {           
            tc += Time.deltaTime;
            if(tc > 0 && tc <= 15)
            {
                warningText.color = lblue;
            }
            if (tc > 15 && tc <= 30)
            {
                warningText.color = dblue;
                tc = 0;
            }
            //randomize repair event
            switch (repairType)
            {
                case 0:
                    warningText.text = strings[0];
                    
                    if(mb.buttonState == false)
                    {
                        isPressed = false;
                    }
                    if(mb.buttonState == true && isPressed == false)
                    {
                        isPressed = true;
                        mashVal += 1;
                    }
                    if (mashVal >= 10)
                    {
                        Repair();
                        mashVal = 0;
                    }

                    break;
                case 1:
                    warningText.text = strings[1];
                    
                    if(start == true)
                    {
                        isPressed = pb.pullCordState;
                        start = false;
                    }
                    
                    if (isPressed != pb.pullCordState)
                    {
                        Repair();
                        start = true;  
                    }
                    break;
            }
        }
        else
        {
            if (isReload)
            {
                {
                    time += Time.deltaTime;
                    if (time > reloadingTime)
                    {
                        time = 0;
                        warningText.text = null;
                        isReload = false;
                    }
                    else
                    {
                        warningText.text = "FIXING";
                    }
                }
            }
        }
     
    }
    void Repair()
    {
        repairType = Random.Range(0, 2);
        rs.isBroken = false;
        isReload = true;
        Debug.Log(repairType);
    }
    
}