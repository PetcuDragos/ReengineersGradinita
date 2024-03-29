using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEngine;

public class CountMistakes : MonoBehaviour
{
    private int mistakes;
    private int matches;
    private bool final;
    public GameObject confetti;
    public GameObject nextGameButton;
    public AudioSource source;
    public AudioClip felicitari;
    public GameObject currentGame;
    public GameObject nextGame;
    private bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Score[Game.Four] != -1)
        {
            currentGame.SetActive(false);
            nextGame.SetActive(true);
        }
        else
        {
            confetti.SetActive(false);
            mistakes = 0;
            matches = 0;
            final = false;
        }
    }

    public void addMistake() {
        mistakes += 1;
    }

    public void addMatch() {
        matches += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (matches == 10 && !final)
        {
            Debug.Log("final joc!");
            Debug.Log(mistakes);
            final = true;
            source.PlayOneShot(felicitari);
            confetti.SetActive(true);
            gameEnded = true;
            //nextGameButton.SetActive(true);
        }
        if(gameEnded && !source.isPlaying)
        {
            NextGame();
        }
    }

    private void NextGame()
    {
        var finalScore = matches * 20 - mistakes * 5;
        GameManager.Instance.Score[Game.Four] = finalScore;
        GameManager.Instance.SaveScoreForCurrentChild();
        
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
