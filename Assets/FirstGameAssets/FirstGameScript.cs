using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGameScript : MonoBehaviour
{

    public static int score = 0;
    private int currentItemIndex = -1;
    public GameObject[] items;
    public GameObject currentGame;
    public GameObject nextGame;
    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip final;
    private bool endGameHandlerStarted = false;
    // Start is called before the first frame update

    private void ShowNextItem()
    {
        currentItemIndex++;
        items[currentItemIndex].SetActive(true);
    }

    void Start()
    {
        audioSource.clip = intro;
        audioSource.Play();
        ShowNextItem();
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
        GameManager.Instance.Score[Game.Two] = score;
        endGameHandlerStarted = true;
        audioSource.clip = final;
        audioSource.Play();
    }

    private void EndGame()
    {
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
