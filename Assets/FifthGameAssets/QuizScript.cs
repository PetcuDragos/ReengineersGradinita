using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip intro;
    public GameObject quizStart;
    public AudioClip final;
    public GameObject currentGame;
    public GameObject nextGame;

    private bool introStarted = false;
    private bool introFinished = false;
    private bool finalStarted = false;
    private bool finalFinished = false;

    public static bool gameEnded = false;

    public static float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = intro;
        audioSource.Play();
        introStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!introFinished && introStarted && !audioSource.isPlaying)
        {
            introFinished = true;
            StartQuiz();
        }
        if(gameEnded && !finalStarted)
        {
            finalStarted = true;
            audioSource.clip = final;
            audioSource.Play();
        }
        if(gameEnded && finalStarted && !finalFinished && !audioSource.isPlaying)
        {
            finalFinished = true;
            EndGame();
        }
    }

    private void StartQuiz()
    {
        quizStart.SetActive(true);
    }

    private void EndGame()
    {
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
