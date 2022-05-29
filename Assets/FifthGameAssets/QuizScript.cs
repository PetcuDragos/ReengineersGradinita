using System;
using System.Collections;
using System.Collections.Generic;
using GameState;
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

    private int score = 0;
    private Action increaseScore;
    private Action decreaseScore;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Score[Game.Five] != -1)
        {
            currentGame.SetActive(false);
            nextGame.SetActive(true);
        }
        // Reset static state
        gameEnded = false;

        // Subscribe to right/wrong answer events
        increaseScore = () => score += 10;
        decreaseScore = () => score -= 3;
        QuestionScript.OnCorrectAnswer += increaseScore;
        QuestionScript.OnWrongAnswer += decreaseScore;
        
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
        // Unsubscribe from right/wrong answer events
        QuestionScript.OnCorrectAnswer -= increaseScore;
        QuestionScript.OnWrongAnswer -= decreaseScore;
        
        GameManager.Instance.Score[Game.Five] = score;
        GameManager.Instance.SaveScoreForCurrentChild();
        
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
