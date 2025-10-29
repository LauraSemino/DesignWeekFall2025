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
    float charge;
    public Slider chargeUI;
    float shootDistance;

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
            if (!isReload)
            {
                chargeShoot();
            }
            //AFTER RELOADING BREAK GUN
        }

    }
    void Repair()
    {
        repairType = RandomNumberInRangeExcluding(3);
        isBroken = false;
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
    void chargeShoot()
    {
        chargeUI.value = charge;
        if (Input.GetKey(KeyCode.Space))
        {
            if (charge <= 1)
            {
                charge += Time.deltaTime / 2;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shoot();
        }
    }
    void shoot()
    {
        if (charge >= 0.33)
        {
            shootDistance = charge * shootDistance;
            Debug.Log("Shoot");
        }
        if (charge <= 0.33)
        {
            shootDistance = 0;
            Debug.Log("Fail");
        }

        int breakChance;
        breakChance = Random.Range(0, 5);
        if (breakChance == 1)
        {
            isBroken = true;
            Debug.Log("break");
        }
        charge = 0;
    }
}