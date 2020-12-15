using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class TutorialAnimation : MonoBehaviour

    
{
    Animator animator;
    AudioSource audioData;
    private GameObject sneukie;
    Animator sneukieAn;

    public GameObject duw;
    AudioSource duwAudio;

    // Start is called before the first frame update
    void Start()
    {
        duwAudio = duw.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        //sneukieAn = sneukie.GetComponent<Animator>();
        StartCoroutine(DelayedAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(audioData.isPlaying);
    }

    void playAudio ()
    {
        //Debug.Log("play");
        //Debug.Log(audioData.isPlaying);
        audioData.Play(0);
    }

    IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(1.9f);
        
        playAudio();
        animator.SetFloat("step", 0.6f);
        yield return new WaitForSeconds(3.0f);
        animator.SetFloat("step", 1.0f);
        yield return new WaitForSeconds(42.0f); //42
        Debug.Log("beestje opkomen");
        sneukie = GameObject.Find("sneukietje");
        sneukieAn = sneukie.GetComponent<Animator>();
        sneukieAn.SetFloat("sneukieStep", 1.0f);
        //yield return new WaitForSeconds(2f);
        //duwAudio.Play(0);
        
    }
}
