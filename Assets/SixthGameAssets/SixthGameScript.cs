using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthGameScript : MonoBehaviour
{

    public static int score = 0;
    public GameObject trafficGame;
    public GameObject beachGame;
    public GameObject currentGame;
    public GameObject nextGame;
    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip final;

    private bool endGameHandlerStarted = false;
    
    private bool introStarted = false;
    private bool introEnded = false;

    private bool trafficGameStarted = false;
    public static bool trafficGameFinished = false;

    private bool beachGameStarted = false;
    public static bool beachGameFinished = false;

    private bool gameEnded = false;
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
        if(introStarted && !introEnded && !audioSource.isPlaying)
        {
            introEnded = true;
            if (!trafficGameStarted)
            {
                if (trafficGame != null)
                {
                    trafficGame.SetActive(true);
                }
                else
                {
                    trafficGameFinished = true;
                }
                trafficGameStarted = true;
            }
        }
        if(trafficGameStarted && trafficGameFinished && !beachGameStarted)
        {
            beachGameStarted = true;
            if (beachGame != null)
            {
                beachGame.SetActive(true);
            }
            else
            {
                beachGameFinished = true;
            }
            beachGameStarted = true;
        }
        if(trafficGameFinished && beachGameFinished)
        {
            gameEnded = true;
        }
        if(gameEnded && !endGameHandlerStarted)
        {
            StartEndGame();
        }
        else if(gameEnded && endGameHandlerStarted && !audioSource.isPlaying)
        {
            EndGame();
        }
    }

    private void StartEndGame()
    {
        endGameHandlerStarted = true;
        if (final != null)
        {
            audioSource.clip = final;
            audioSource.Play();
        }
    }

    private void EndGame()
    {
        GameManager.Instance.Score[Game.Six] = score;
        GameManager.Instance.SaveScoreForCurrentChild();
        
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
