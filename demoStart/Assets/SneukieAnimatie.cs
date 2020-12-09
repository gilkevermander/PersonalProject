using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneukieAnimatie : MonoBehaviour
{
    GameObject sneukie;
    public bool gifregen = false; //geconnect worden aan gifregen!!!!
    public bool dor = false;
    public bool sneu;
    
    Animator sneukieAn;
    //AudioSource sound;
    //ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        sneukie = this.gameObject.transform.GetChild(2).gameObject;
        sneukieAn = sneukie.GetComponent<Animator>();

        sneukie.SetActive(false);
        sneu = false;
        dor = false;
        //Debug.Log(GetComponent<Renderer>().material.color);
        //Debug.Log(this.gameObject.GetComponent<Renderer>().material.color);

    }

    // Update is called once per frame
    void Update()
    {
        if (gifregen == false && dor == false && sneu == false)
        {
            sneu = true; //als hij ergens elders gedestoryed wordt dan gaat sneu terug op false en kan er een nieuwe ontstaan.
            StartCoroutine(animateSneukie());
            StartCoroutine(dorBloem());
        }

        if(dor == true)
        {
            //materials veranderen
            //animatie dor worden
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    IEnumerator animateSneukie()
    {
        //yield return new WaitForSeconds(4.0f); //sws wachten tot het gedaan is.
        //int delay = 6;
        int delay = Random.Range(6, 16);
        yield return new WaitForSeconds(delay);
        sneukie.SetActive(true);
        sneukieAn.SetFloat("sneukieStep", 1.0f);
    }

    IEnumerator dorBloem()
    {
        while (sneu == true)
        {
            int difficulty = 30;
            yield return new WaitForSeconds(difficulty);
            dor = true;
        }
        
    }
}
