using TMPro;
using UnityEngine;

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
    public AudioClip[] audioClips;
    public AudioSource reloadSound;
    bool errorSound;

    public float mashVal;

    public Color lblue;
    public Color dblue;
    float tc;

    public RotaryScript rs;

    void Start()
    {
        //isBroken = true;
        //Repair();
        mashVal = 0;
        warningText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        isBroken = rs.isBroken;

        if (isBroken)
        {
            if (!errorSound)
            {
                reloadSound.clip = audioClips[1];
                reloadSound.Play();
                errorSound = true;
            }
            switch (repairType)
            {
                case 0:
                    warningText.text = strings[0];

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
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

                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        Repair();
                    }
                    break;
                case 2:
                    warningText.text = strings[2];

                    if (Input.GetKeyDown(KeyCode.M))
                    {
                        Repair();
                    }
                    break;
                case 3:
                    warningText.text = strings[3];

                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        mashVal += 1;
                    }
                    if (mashVal >= 10)
                    {
                        Repair();
                        mashVal = 0;
                    }
                    break;
                case 4:
                    warningText.text = strings[4];

                    if (Input.GetKey(KeyCode.F))
                    {
                        if (Input.GetKey(KeyCode.G))
                        {
                            if (Input.GetKey(KeyCode.H))
                            {
                                Repair();
                            }
                        }
                    }
                    break;
                case 5:
                    warningText.text = strings[5];

                    if (Input.GetMouseButtonDown(1))
                    {
                        Repair();

                    }
                    break;
                case 6:
                    warningText.text = strings[6];

                    if (Input.mousePosition.y <= 100)
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
        reloadSound.clip = audioClips[0];
        reloadSound.Play();
        repairType = Random.Range(0, 7);
        errorSound = false;
        rs.isBroken = false;
        isReload = true;
        Debug.Log(repairType);
    }

}