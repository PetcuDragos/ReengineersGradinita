using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChamberSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    public GameObject[] keys;
    public AudioClip[] keysInstructions;
    public AudioSource source;
    public AudioClip intro;
    public AudioClip final;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public GameObject currentGame;
    public GameObject nextGame;
    public GameObject instructionButton;
    private int[] chosenKeys;
    private int currentIndex = 0;
    private bool canGoToNextGame = false;
    private bool introStarted = false;
    private bool introEnded = false;

    private bool confirmationMessageStarted = false;
    private void Shuffle()
    {
        chosenKeys = new int[keys.Length];
        for (int i = 0; i < keys.Length; i++)
        {
            chosenKeys[i] = i;
        }
        for (int i = 0; i < chosenKeys.Length; i++)
        {
            int rnd = Random.Range(0, chosenKeys.Length - 1);
            int temp = chosenKeys[rnd];
            chosenKeys[rnd] = chosenKeys[i];
            chosenKeys[i] = temp;
        }
    }
    void Start()
    {
        source.PlayOneShot(intro);
        introStarted = true;
        Shuffle();
        
        for(int i = 0; i < chosenKeys.Length; i ++)
        {
            var i1 = i;
            Button button = keys[i].GetComponent<Button>();
            button.onClick.AddListener(() => { ButtonClicked(i1); });
        }
        instructionButton.GetComponent<Button>().onClick.AddListener(() => PlayInstruction());

    }

    void ButtonClicked(int index)
    {
        //Debug.Log("index " + index + " current " + chosenKeys[currentIndex]);
        if(index == chosenKeys[currentIndex])
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
    }

    void Correct()
    {
        score += 1;
        confirmationMessageStarted = true;
        if(currentIndex < 5 - 1) 
        { 
            source.clip = correctSound;
            source.Play();
        }
    }

    void Incorrect()
    {
        score -= 1;
        source.clip = incorrectSound;
        source.Play();
    }

    void ChangeCurrentIndex()
    {
        currentIndex += 1;
        if (currentIndex < 5)
        {
            PlayInstruction();
        }
    }

    void PlayInstruction()
    {
        //Debug.Log(chosenKeys[currentIndex]);
        source.clip = keysInstructions[chosenKeys[currentIndex]];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentIndex >= 5 && !source.isPlaying && !canGoToNextGame)
        {
            StopGame();
        }
        if(canGoToNextGame && !source.isPlaying)
        {
            NextGame();
        }

        if (introStarted && !source.isPlaying && !introEnded)
        {
            introEnded = true;
            PlayInstruction();
        }

        if(confirmationMessageStarted && !source.isPlaying)
        {
            confirmationMessageStarted = false;
            ChangeCurrentIndex();
        }
    }

    void StopGame()
    {
        GameManager.Instance.Score[Game.Three] = score;
        GameManager.Instance.SaveScoreForCurrentChild();
        
        source.clip = final;
        source.Play();
        canGoToNextGame = true;
    }

    void NextGame()
    {
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }

}
