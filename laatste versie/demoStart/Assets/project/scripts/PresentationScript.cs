using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class PresentationScript : MonoBehaviour 
{

    Renderer[] children;

    public bool uitlegObject = true;

	public Image load;
    public float waitTime = 5.0f;

    public GameObject musicObject;

    public GameObject sneukie;

    AudioSource sound;
    AudioSource take2;
    AudioSource take3;
    AudioSource take4;
    AudioSource take5;
    AudioSource soundSneu;
    AudioSource soundBloem;
    AudioSource music;

    public TextMeshProUGUI startText;

    private ParticleSystem particle;
    private ParticleSystem bloemParticle;
    private ParticleSystem sneuParticle;
    private ParticleSystem bloemGameParticle;

    private int maxSides = 0;
	private int maxTextures = 0;
	private int side = 0;
	private int tex = 0;
	private bool isSpinning = false;
	private float slideWaitUntil;
	private Quaternion targetRotation;

    public GameObject paraplu1;
    public GameObject paraplu2;
    public GameObject gif;
    public GameObject take;
    public GameObject goed;
    private GameObject bloem;
    private GameObject lastSneu;
    private GameObject lastBloem;
    public GameObject start;
    public GameObject SpawnBloemen;
    public GameObject SpawnGif;

    public GameObject zwaai;

    AudioSource zwaaiAudio;
    public GameObject duw;
    AudioSource duwAudio;


    AudioSource bloemaudio;

    public Slider honing;

    ParticleSystem honingParticle;

    private GameObject[] SneukiePrefabs;

    public List<GameObject> sneus;
    public List<GameObject> doreBloemen;

    public GameObject gifCha;
    public GameObject line;

    public GameObject slice;
    public GameObject uitleg;
    Animator SliceAnimator;
    Animator sneukieAn;
    Animator GifAnimator;
    Animator lineAnimator;

    public float startDelay = 0;
    public float startInterval = 1f;

    public float fadeSpeed = 10.0f;

    private GestureListener gestureListener;
	

	
	void Start() 
	{
		// hide mouse cursor
		Cursor.visible = false;

        particle = sneukie.GetComponentInChildren<ParticleSystem>();
        honingParticle = honing.GetComponentInChildren<ParticleSystem>();
        sound = sneukie.GetComponentInChildren<AudioSource>();
        take2 = GetComponent<AudioSource>();
        take3 = take.GetComponent<AudioSource>();
        take4 = goed.GetComponent<AudioSource>();
        take5 = start.GetComponent<AudioSource>();
        sneukieAn = sneukie.GetComponent<Animator>();
        lineAnimator = line.GetComponent<Animator>();
        music = musicObject.GetComponent<AudioSource>();
        zwaaiAudio = zwaai.GetComponent<AudioSource>();
        duwAudio = duw.GetComponent<AudioSource>();



        SliceAnimator = slice.GetComponent<Animator>();
        GifAnimator = gifCha.GetComponent<Animator>();
      
		
		// get the gestures listener
		gestureListener = Camera.main.GetComponent<GestureListener>();
        //Debug.Log(SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "Uitleg")
        {
        
            paraplu1.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.5163f, 0.0901f, 0f);
            paraplu2.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.5163f, 1.0f, 0f);
            paraplu1.SetActive(false);
            paraplu2.SetActive(false);
        }

    }
	
	void Update() 
	{
        Debug.developerConsoleVisible = false;
        //Debug.Log(paraplu1.GetComponent<MeshRenderer>().material.color.a);
        sneukie = GameObject.Find("sneukietje");
        // dont run Update() if there is no user
        KinectManager kinectManager = KinectManager.Instance;
		if(!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected())
			return;
		

        if (honing.value == 1.0f)
        {
            StartCoroutine(endGame());
            
        }

        if (gestureListener)
			{
				if(gestureListener.IsJump())
                {
                //laad start knop
                Debug.Log("jump");
                    if (SceneManager.GetActiveScene().name != "Uitleg")
                    {
                        StartGame();
                    }

                }
                else if (gestureListener.IsPush())
                {
                    Debug.Log("push");

                    if (sneukie != null && sneukieAn.GetFloat("sneukieStep") == 1.0f && uitlegObject == true )
                    {
                        Debug.Log("kill sneukie");
                    //Destroy(sneukie);
                        duwAudio.Stop();
                        StartCoroutine(Break());
                    }

                    if (uitlegObject == false)//false gilke
                    {
                        //Debug.Log("sneus");
                        sneus = new List<GameObject>();
                        //Debug.Log(sneus.Count);
                        //spel push
                        //lijst met alle huidige actieve sneukies ophalen. Checken of de lijst zeker iets bevat. als dat zo is moet de 0 object verwijderd worden.
                        foreach (GameObject gameObj in FindObjectsOfType<GameObject>())
                        {
                            //Debug.Log(gameObj.name);
                            if (gameObj.name == "sneu")
                            {
                                if (gameObj.GetComponent<Animator>().GetFloat("sneukieStep") == 1.0f)
                                {
                                    //toevoegen in array
                                    sneus.Add(gameObj);
                                    //Debug.Log(sneus.Count);
                                }
                            
                            }    
                        }
                        //Debug.Log("total" + sneus.Count);
                        // nu heb ik een lijst
                        // variabele eerste van lijst
                        if (sneus.Count > 0)
                        {
                            StartCoroutine(SneukieDestroyGame());
                            
                        }
                        
                    }
                }
                else if(gestureListener.IsSwipeRight() || gestureListener.IsSwipeLeft())
                {
                    //hak bloem om xxx
                    if(bloem != null)//en de bloem is dor!
                    {
                        if (uitlegObject == true)
                        {
                            StartCoroutine(DestroyFlower());
                        }
                        else
                        {
                        //debug
                        }
                    }

                    //hier
                    if (uitlegObject == false) // false gilke
                    {
                        doreBloemen = new List<GameObject>();
                        foreach (GameObject gameObj in FindObjectsOfType<GameObject>())
                        {
                            //Debug.Log(gameObj.name);
                            if (gameObj.name == "bloemSpawn 1(Clone)")
                            {
                                if (gameObj.GetComponent<SneukieAnimatie>().dor == true)
                                {
                                    //toevoegen in array
                                    doreBloemen.Add(gameObj);
                                }

                            }
                        }
                    //Debug.Log("total: " + doreBloemen.Count);
                    Debug.Log(doreBloemen);
                    }

                    if (doreBloemen.Count > 0)
                    {
                        StartCoroutine(BloemDestroyGame());

                    }


                }
                else if (gestureListener.IsTpose())
                {
                    Debug.Log(gestureListener.user);
                    //hak bloem om xxx
                    if(gestureListener.user == 0)
                    {
                    paraplu2.SetActive(true);
                    Debug.Log("speler 2");
                        StartCoroutine(FadeOutObject2());
                    //eerste paraplu zichtbaar maken
                    }
                    else if (gestureListener.user == 1)
                    {
                    paraplu1.SetActive(true);
                    Debug.Log("speler 1");
                    StartCoroutine(FadeOutObject());
                    //tweede paraplu zichtbaar maken
                }
            }
        }
	
		
	}

    public IEnumerator endGame()
    {
        SceneManager.LoadScene("End");
        yield return null;
    }

    public IEnumerator BloemDestroyGame()
    {
        lastBloem = doreBloemen[0];
        bloemGameParticle = lastBloem.GetComponentInChildren<ParticleSystem>();
        soundBloem = lastBloem.GetComponentInChildren<AudioSource>();

        Debug.Log(lastBloem.transform.position.x);

        if (lastBloem.transform.position.x == -4.5f)
        {
            Debug.Log("bloem1 false");
            SpawnBloemen.GetComponent<spawnBloemen>().bloem1 = false;
        } else
        if (lastBloem.transform.position.x <= -3.8f)
        {
            Debug.Log("bloem2 false");
            SpawnBloemen.GetComponent<spawnBloemen>().bloem0 = false;
        } else
        if (lastBloem.transform.position.x >= -5.1f)
        {
             Debug.Log("bloem0 false");
            SpawnBloemen.GetComponent<spawnBloemen>().bloem2 = false;
        }

        

        lastBloem.transform.localScale = new Vector3(0, 0, 0);

        soundBloem.Play(0);
        bloemGameParticle.Play();
        //Debug.Log("break");
        yield return new WaitForSeconds(bloemGameParticle.main.startLifetime.constantMax);
        // variaele verwijderen van lijst
        doreBloemen.Remove(lastBloem);
        Destroy(lastBloem);
        //lastBloem.transform.localScale = new Vector3(1, 1, 1);
        // bloem op vals zetten
        honing.value += 0.05f; //0.2 gilke
        honingParticle.Play();
    }

    public IEnumerator SneukieDestroyGame()
    {
        lastSneu = sneus[0];

        sneuParticle = lastSneu.GetComponentInChildren<ParticleSystem>();
        soundSneu = lastSneu.GetComponentInChildren<AudioSource>();

        lastSneu.transform.localScale = new Vector3(0, 0, 0);

        soundSneu.Play(0);
        sneuParticle.Play();
        //Debug.Log("break");
        yield return new WaitForSeconds(sneuParticle.main.startLifetime.constantMax);
        // variaele verwijderen van lijst
        lastSneu.SetActive(false);
        lastSneu.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        // sneu op vals zetten
        lastSneu.transform.parent.gameObject.GetComponent<SneukieAnimatie>().dorCountdown = false;
        lastSneu.transform.parent.gameObject.GetComponent<SneukieAnimatie>().sneu = false;
         //ervoor zorgen dat de coroutine stopt
        sneus.Remove(lastSneu);
        honing.value += 0.05f; //0.2 gilke
        honingParticle.Play();
        
    }


    private IEnumerator DestroyFlower()
    {
        //Debug.Log("break");
        bloem.transform.localScale = new Vector3(0, 0, 0);
        bloemParticle.Play();
        bloemaudio.Play(0);
        line.SetActive(true);
        yield return new WaitForSeconds(bloemParticle.main.startLifetime.constantMax);
        yield return new WaitForSeconds(1.0f);
        Destroy(bloem);
        take3.Stop();
        zwaaiAudio.Stop();
        take4.Play(0);
        yield return new WaitForSeconds(5.0f);
        take5.Play(0);
        //3 bloemen moeten gestart worden
        GameObject thePlayer = GameObject.Find("SpawnBloemen");
        spawnBloemen playerScript = thePlayer.GetComponent<spawnBloemen>();
        playerScript.bloem0 = false;
        yield return new WaitForSeconds(0.5f);
        playerScript.bloem1 = false;
        yield return new WaitForSeconds(0.5f);
        playerScript.bloem2 = false;
        yield return new WaitForSeconds(1.0f);
        music.Play(0);
        startText.text = "3";
        yield return new WaitForSeconds(1.0f);
        startText.text = "2";
        yield return new WaitForSeconds(1.0f);
        startText.text = "1";
        yield return new WaitForSeconds(1.0f);
        startText.text = "Start";
        slice.SetActive(false); //lauren moet weg
        yield return new WaitForSeconds(1.0f);
        startText.text = "";

        //uitleg bool moet false worden.
        uitlegObject = false;
        Debug.Log(uitlegObject);
        
        StartCoroutine(gifRegen());
    }

    private IEnumerator gifRegen()
    {
        yield return new WaitForSeconds(40.0f);
        SpawnGif.GetComponent<GifRegenManager>().invoke();
        yield return new WaitForSeconds(10.0f);
        SpawnGif.GetComponent<GifRegenManager>().cancel();
        yield return new WaitForSeconds(100.0f);
        SpawnGif.GetComponent<GifRegenManager>().invoke();
        yield return new WaitForSeconds(10.0f);
        SpawnGif.GetComponent<GifRegenManager>().cancel();
    }

    private IEnumerator Break()
    {
        //Debug.Log("break");
        sneukie.transform.localScale = new Vector3(0, 0, 0);
        sound.Play(0);
        particle.Play();
        //Debug.Log("break");
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(sneukie);
        yield return new WaitForSeconds(1.0f);
        //mannetje veranderen naar gif
        uitleg.SetActive(false);
        gifCha.SetActive(true);
        GifAnimator.SetFloat("step", 1.0f);
        take2.Play(0);
        yield return new WaitForSeconds(16.0f);
        SpawnGif.GetComponent<GifRegenManager>().invoke();
        yield return new WaitForSeconds(15.0f);
        SpawnGif.GetComponent<GifRegenManager>().cancel();//false zijn
        yield return new WaitForSeconds(1.0f);
        //slice uitleg spelen
        
        //mannetje gif onzichtbaar maken
        gifCha.SetActive(false);
        slice.SetActive(true);
        //mannetje veranderen naar slice
        SliceAnimator.SetFloat("step", 1.0f);
        take3.Play(0);
        //animatie slice starten
        yield return new WaitForSeconds(11.0f);
        
        bloem = GameObject.Find("finalbloem");
        bloemParticle = bloem.GetComponentInChildren<ParticleSystem>();
        bloemaudio = bloem.GetComponentInChildren<AudioSource>();

        children = bloem.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            Debug.Log(rend.material.GetColorArray("_Color"));
            rend.material.color = Color.gray;
        }
        zwaaiAudio.Play(0);
    }

    public IEnumerator FadeOutObject() {
        
        yield return new WaitForSeconds(5.0f);
        paraplu1.SetActive(false);
    }

    public IEnumerator FadeOutObject2()
    {
       
        yield return new WaitForSeconds(5.0f);
        paraplu2.SetActive(false);
    }


    private void StartGame()
    {
        load.fillAmount += 155.0f / waitTime * Time.deltaTime;

        if (load != null && load.fillAmount == 1)
        {
            //roep uitleg functie op om spel te starten
            ToUitleg();
        }
    }

    void ToUitleg()
    {
        SceneManager.LoadScene("Uitleg");
    }
}
