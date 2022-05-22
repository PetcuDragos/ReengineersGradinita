using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficGameScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip final;
    public GameObject firstLevel;

    public static bool gameEnded = false;

    private bool introStarted = false;
    private bool introEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        if (intro != null)
        {
            audioSource.clip = intro;
            audioSource.Play();
        }
        introStarted = true;
    }

   

    // Update is called once per frame
    void Update()
    {
        if(!introEnded && introStarted && !audioSource.isPlaying)
        {
            introEnded = true;
            firstLevel.SetActive(true);
        }
        if(gameEnded)
        {
            SixthGameScript.trafficGameFinished = true;
        }
    }
}
