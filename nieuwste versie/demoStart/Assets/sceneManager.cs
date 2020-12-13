using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(scenemanage());
    }

    public IEnumerator scenemanage ()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("KinectGesturesDemo");

    }
}
