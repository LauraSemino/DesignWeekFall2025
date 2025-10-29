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

    public TurnyThing tt;

    //crank fix
    public bool check1 = false;
    public bool check2 = false;

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

        warningText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        isBroken = rs.isBroken;
        
        if (isBroken)
        {
            //randomize repair event
            switch (repairType)
            {
                case 0:
                    warningText.text = strings[0];
                    
                    if (tt.output <= 30)
                    {
                        Debug.Log("check 1");
                        check1 = true; 
                    }
                    if (tt.output >= 95)
                    {   
                        Debug.Log("check 2");
                        check2 = true; 
                    }
                    if(check1 && check2 == true)
                    {
                        Repair();
                        check1 = false;
                        check2 = false;
                    }
                    break;
                case 1:
                    warningText.text = strings[1];
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Repair();
                    }
                    break;
                case 2:
                    warningText.text = strings[2];
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Repair();
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
        repairType = RandomNumberInRangeExcluding(3);
        rs.isBroken = false;
        isReload = true;
        Debug.Log(repairType);
    }
    public int RandomNumberInRangeExcluding(int range)
    {
        int r = ExNum;
        while (r == ExNum)
        {
            r = Random.Range(0, range);
        }
        ExNum = r;
        return r;
    }
}