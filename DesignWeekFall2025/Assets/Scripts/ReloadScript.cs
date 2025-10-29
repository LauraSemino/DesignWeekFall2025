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
    /*
    public Slider chargeUI;
    float charge;
    float shootDistance;
    */

    public RotaryScript rs;

    void Start()
    {
        //isBroken = true;
        Repair();
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
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Repair();
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
                        isReload = false;
                    }
                    else
                    {
                        warningText.text = "RELOADING";
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