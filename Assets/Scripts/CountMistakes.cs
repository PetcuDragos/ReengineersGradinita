using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        nextGameButton.SetActive(true);
        confetti.SetActive(false);
        mistakes = 0;
        matches = 0;
        final = false;
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
        if (matches == 10 && !final) {
            Debug.Log("final joc!");
            Debug.Log(mistakes);
            final = true;
            source.PlayOneShot(felicitari);
            confetti.SetActive(true);
            //nextGameButton.SetActive(true);
        }
    }
}
