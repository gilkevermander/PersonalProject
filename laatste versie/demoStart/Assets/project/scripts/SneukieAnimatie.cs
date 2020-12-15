using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneukieAnimatie : MonoBehaviour
{
    GameObject sneukie;
    public bool gifregen = false; //geconnect worden aan gifregen!!!!
    public bool dor = false;
    public bool sneu;
    public bool dorCountdown;
    public float theTime = 0;
    public GameObject dorGameobject;
    AudioSource dorSound;

    Renderer[] children;

    Material mat;

    Coroutine co;

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
        theTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(theTime);

        if (gifregen == false && dor == false && sneu == false)
        {
            sneu = true; //als hij ergens elders gedestoryed wordt dan gaat sneu terug op false en kan er een nieuwe ontstaan.
            StartCoroutine(animateSneukie());
            //co = StartCoroutine(dorBloem());
        }

        if(dor == true)
        {
            //materials veranderen
            //animatie dor worden
            children = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                Debug.Log(rend.material.GetColorArray("_Color"));
                rend.material.color = Color.gray;
            }
                // geluids effect
            dorSound = dorGameobject.GetComponent<AudioSource>();
            dorSound.Play(0);
        }

        if (dorCountdown == true)
        {
            // start countdown
            theTime += Time.deltaTime;
            
            if (theTime >= 7.0f)
            {
                dor = true;
            }
        }

        if (dorCountdown != true)
        {
            theTime = 0;
        }

    }

    public IEnumerator animateSneukie()
    {
        //yield return new WaitForSeconds(4.0f); //sws wachten tot het gedaan is.
        //int delay = 6;
        int delay = Random.Range(6, 16);
        yield return new WaitForSeconds(delay);
        sneukie.SetActive(true);
        dorCountdown = true;
        sneukieAn.SetFloat("sneukieStep", 1.0f);
    }

    //public IEnumerator dorBloem()
    //{
    //    for (float timer = 5; timer >= 0; timer -= Time.deltaTime)
    //    {
    //        if (stop != true)
    //        {
    //            //bloem moet dor worden
    //            yield break;
    //        }
    //        //hij blijft goed.
    //        yield return null;
    //    }
    //}
}
