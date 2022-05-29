using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip question;
    public AudioClip[] answersAudio;
    public GameObject[] answersPhoto;
    public int correctIndex;
    public GameObject code;
    public AudioClip correct;
    public AudioClip wrong;
    public GameObject nextQuiz;
    public GameObject instructionButton;
    private bool gameEnded = false;

    private int score = 0;

    private bool correctHasStarted = false;
    private bool A1HasStarted = false;
    private bool A2HasStarted = false;
    private bool A3HasStarted = false;
    private bool A4HasStarted = false;    
    
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = question;
        audioSource.Play();
        for(int i = 0; i < answersPhoto.Length; i ++)
        {
            Button button = answersPhoto[i].GetComponent<Button>();
            var i1 = i;
            button.onClick.AddListener(() => { ButtonClicked(i1); });
        }
        instructionButton.GetComponent<Button>().onClick.RemoveAllListeners();
        instructionButton.GetComponent<Button>().onClick.AddListener(() => ReplayInstruction());
    }

    private void ButtonClicked(int index)
    {
        if (!correctHasStarted)
        {
            if (index == correctIndex)
            {
                audioSource.clip = correct;
                audioSource.Play();
                correctHasStarted = true;
                score += 10;
            }
            else
            {
                audioSource.clip = wrong;
                audioSource.Play();
                score -= 3;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && !correctHasStarted)
        {
            if (!A1HasStarted && answersAudio.Length > 0 && answersAudio[0] != null)
            {
                audioSource.clip = answersAudio[0];
                audioSource.Play();
                A1HasStarted = true;
            }
            else if (!A2HasStarted && answersAudio.Length > 1 && answersAudio[1] != null)
            {
                audioSource.clip = answersAudio[1];
                audioSource.Play();
                A2HasStarted = true;
            }
            else if (!A3HasStarted && answersAudio.Length > 2 && answersAudio[2] != null)
            {
                audioSource.clip = answersAudio[2];
                audioSource.Play();
                A3HasStarted = true;
            }
            else if (!A4HasStarted && answersAudio.Length > 3 && answersAudio[3] != null)
            {
                audioSource.clip = answersAudio[3];
                audioSource.Play();
                A4HasStarted = true;
            }
        }
        else if (!audioSource.isPlaying && correctHasStarted && !gameEnded)
        {
            gameEnded = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        QuizScript.score += score;
        code.GetComponent<TextMeshProUGUI>().text += (correctIndex+1);
        if(nextQuiz != null)
        {
            this.gameObject.SetActive(false);
            nextQuiz.SetActive(true);
        }
        else
        {
            QuizScript.gameEnded = true;
        }
    }

    private void ReplayInstruction()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = question;
            audioSource.Play();
        }
    }
}
