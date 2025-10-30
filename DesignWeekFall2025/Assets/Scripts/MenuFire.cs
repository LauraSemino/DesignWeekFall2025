using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFire : MonoBehaviour
{
    public ButtonScript bs;

    public float charge;
    public Slider chargeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bs.pullCordState == true)
        {
            charge += 5f * Time.deltaTime;
            if (charge >= 15f)
            {
                charge = 0;
               
                //do a malfunction here
            }
        }
        if (bs.pullCordState == false)
        {
            if (charge >= 5)
            {
                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                SceneManager.UnloadSceneAsync("GameOver");
                SceneManager.UnloadSceneAsync("TitleScreen");
            }
            else
            {
                charge = 0;

                //potentially do a malfunction here
            }

        }
        chargeUI.value = charge / 15;
    }
}
