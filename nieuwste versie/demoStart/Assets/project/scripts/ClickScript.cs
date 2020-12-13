using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickScript : MonoBehaviour

{

    public Text text;
    public Image load;
    public bool loadingState;
    public float waitTime = 5.0f; // de snelheid waarmee het laad

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != null)
        {
            //checken of de position er is
        
            //afstanden waartussen de cursor moet zijn.
            if (transform.position != null && transform.position.x >= 0.45 && transform.position.x <= 0.55 && transform.position.y >= 0.05 && transform.position.y <= 0.4)
            {
                //het moet loaden. Increase
                load.fillAmount += 1.0f / waitTime * Time.deltaTime;
            } else
            {
                //het moet niet meer loaden dus terug naar beneden gaan. Decrease
                text.text = "no";
                load.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            }
        }

        if (load != null && load.fillAmount == 1)
        {
            //roep uitleg functie op om spel te starten
            text.text = "FULL";
            ToUitleg();
        }
    }

    void ToUitleg()
    {
        SceneManager.LoadScene("Uitleg");
    }
}
