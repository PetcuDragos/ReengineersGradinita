using System;
using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEngine;
using UnityEngine.UI;

public class SecondGameScript : MonoBehaviour
{

    private int score = 0;
    private Action increaseScore;
    private Action decreaseScore;
    
    private int currentItemIndex = -1;
    public GameObject[] items;
    public GameObject currentGame;
    public GameObject nextGame;
    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip final;
    private bool endGameHandlerStarted = false;
    public GameObject instructionButton;

    private void ShowNextItem()
    {
        currentItemIndex++;
        items[currentItemIndex].SetActive(true);
    }

    void Start()
    {
        Debug.Log("joc 2 " + GameManager.Instance.Score[Game.Two]);
        if (GameManager.Instance.Score[Game.Two] != -1)
        {
            currentGame.SetActive(false);
            nextGame.SetActive(true);
        }
        else
        {
            // Subscribe to right/wrong answer events
            increaseScore = () => score += 100;
            decreaseScore = () => score -= 20;
            ItemScript.OnCorrectAnswer += increaseScore;
            ItemScript.OnWrongAnswer += decreaseScore;

            audioSource.clip = intro;
            audioSource.Play();
            instructionButton.GetComponent<Button>().onClick.AddListener(() => ReplayInstruction());
            ShowNextItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentItemIndex >= 0 && !items[currentItemIndex].activeInHierarchy)
        {
            if(currentItemIndex < items.Length - 1)
            {
                ShowNextItem();
            }
            else if(!endGameHandlerStarted)
            {
                StartEndGame();
            }
        }
        if(endGameHandlerStarted && !audioSource.isPlaying)
        {
            EndGame();
        }
    }

    private void StartEndGame()
    {
        endGameHandlerStarted = true;
        audioSource.clip = final;
        audioSource.Play();
    }

    private void ReplayInstruction()
    {
        audioSource.clip = intro;
        audioSource.Play();
    }

    private void EndGame()
    {
        // Unsubscribe from right/wrong answer events
        ItemScript.OnCorrectAnswer -= increaseScore;
        ItemScript.OnWrongAnswer -= decreaseScore;

        GameManager.Instance.Score[Game.Two] = score;
        GameManager.Instance.SaveScoreForCurrentChild();
        
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
