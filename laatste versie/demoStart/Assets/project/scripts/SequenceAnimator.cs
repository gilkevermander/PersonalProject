using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAnimator : MonoBehaviour

    
{
    public List<Animator> _animators;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DoAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var animator in _animators)
        {
            animator.SetTrigger("DoAnimation");
            //yield return new WaitForSeconds(0.15f);
    }
    }
}
