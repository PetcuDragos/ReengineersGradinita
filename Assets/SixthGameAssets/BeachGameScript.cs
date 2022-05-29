using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeachGameScript : MonoBehaviour
{
    public static int numberOfTrashItemsFound = 0;
    
    public AudioSource audioSource;
    public AudioClip intro;
    public int numberOfTrashItems;
    public GameObject instructionButton;
    private bool gameEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Reset static state
        numberOfTrashItemsFound = 0;

        instructionButton.GetComponent<Button>().onClick.AddListener(() => ReplayInstruction());
        if (intro != null)
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
        SixthGameScript.beachGameFinished = true;
    }

    private void ReplayInstruction()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = intro;
            audioSource.Play();
        }
    }
}
