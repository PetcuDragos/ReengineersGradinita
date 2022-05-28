using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachGameScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip intro;
    public int numberOfTrashItems;
    public static int numberOfTrashItemsFound = 0;
    public static int score = 0;

    private bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        if(intro != null)
        {
            audioSource.clip = intro;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfTrashItems == numberOfTrashItemsFound && !gameEnded)
        {
            gameEnded = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        SixthGameScript.score += score;
        SixthGameScript.beachGameFinished = true;
    }
}
