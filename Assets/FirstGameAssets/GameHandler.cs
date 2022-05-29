using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private int score = 100;
    public GameObject ButonAvion;
    public GameObject ButonTren;
    public GameObject ButonVapor;
    public int Alegere;
    public GameObject banut1;
    public GameObject banut2;
    public GameObject banut3;
    public GameObject banut4;
    public GameObject numar1;
    public GameObject numar2;
    public GameObject numar3;
    public GameObject confetti;
    public GameObject nextGameButton;
    public GameObject instructionButton;
    public GameObject currentGame;
    public GameObject nextGame;

    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip gresit;
    public AudioClip outro;

    private float timer = 0f;

    private bool gameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("GameHandler.Start");
        audioSource.clip = intro;
        audioSource.Play();
        instructionButton.GetComponent<Button>().onClick.AddListener(() => ReplayInstruction());
        ButonAvion.GetComponent<Button>().onClick.AddListener(() => AlegAvion());
        ButonTren.GetComponent<Button>().onClick.AddListener(() => AlegTren());
        ButonVapor.GetComponent<Button>().onClick.AddListener(() => AlegVapor());
        confetti.SetActive(false);
        deactivateCoins();
        deactivateNumbers();
        deactivateButtons();
    }

    public void AlegAvion()
    {
        //TextBox.GetComponent<TextMeshProUGUI>().text = "Fisrt choice made";
        Alegere = 1;
        audioSource.clip = gresit;
        audioSource.Play();
        if (score > 30)
            score -= 35;
    }
    public void AlegTren()
    {
        //TextBox.GetComponent<TextMeshProUGUI>().text = "sECOD choice made";
        Alegere = 2;
        audioSource.clip = gresit;
        audioSource.Play();
        if (score > 30)
            score -= 35;
    }
    public void AlegVapor()
    {
        //TextBox.GetComponent<TextMeshProUGUI>().text = "Third choice mate";
        Alegere = 3;
        audioSource.clip = outro;
        audioSource.Play();
        deactivateButtons();
        deactivateCoins();
        deactivateNumbers();
        confetti.SetActive(true);
        gameFinished = true;
        GameManager.Instance.Score[Game.One] = score;
    }

    void activateCoin1() {
        banut1.SetActive(true);
    }

    void activateCoin2()
    {
        banut2.SetActive(true);
    }

    void activateCoin3()
    {
        banut3.SetActive(true);
    }

    void activateCoin4()
    {
        banut4.SetActive(true);
    }

    void activateNumber1() {
        numar1.SetActive(true);
    }

    void activateNumber2()
    {
        numar2.SetActive(true);
    }

    void activateNumber3()
    {
        numar3.SetActive(true);
    }

    void activateButton1() {
        ButonAvion.SetActive(true);
    }

    void activateButton2()
    {
        ButonTren.SetActive(true);
    }

    void activateButton3()
    {
        ButonVapor.SetActive(true);
    }

    void deactivateCoins() {
        banut1.SetActive(false);
        banut2.SetActive(false);
        banut3.SetActive(false);
        banut4.SetActive(false);
    }

    void deactivateNumbers() {
        numar1.SetActive(false);
        numar2.SetActive(false);
        numar3.SetActive(false);
    }

    void deactivateButtons() {
        ButonAvion.SetActive(false);
        ButonTren.SetActive(false);
        ButonVapor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 12.5 && timer < 17) {
            activateCoin1();
        }
        if (timer > 13.5 && timer < 17)
        {
            activateCoin2();
        }
        if (timer > 14.5 && timer < 17)
        {
            activateCoin3();
        }
        if (timer > 15.5 && timer < 17)
        {
            activateCoin4();
        }

        if (timer > 25 && timer < 30)
        {
            activateButton1();
        }
        if (timer > 26 && timer < 30)
        {
            activateButton2();
        }
        if (timer > 27 && timer < 30)
        {
            activateButton3();
        }


        if (timer > 35 && timer < 44)
        {
            activateNumber1();
        }
        if (timer > 38 && timer < 44)
        {
            activateNumber2();
        }
        if (timer > 42 && timer < 44)
        {
            activateNumber3();
        }

        if(gameFinished && !audioSource.isPlaying)
        {
            NextGame();
        }
    }

    private void ReplayInstruction()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = intro;
            audioSource.Play();
        }
    }

    private void NextGame()
    {
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
