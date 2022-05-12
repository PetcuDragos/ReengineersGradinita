using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdGameScript : MonoBehaviour
{
    private static int score = 0;
    private int penalty = 0;
    public GameObject[] prefabWrongButtons;
    public GameObject prefabCorrectButton;
    public RectTransform parentPanel;
    public GameObject nextLevel;
    public GameObject nextGame;
    public AudioSource audioIndication;

    void Start()
    {
        float width = (float) (Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height);
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;
        float keyWidth = 43;
        float keyHeight = 63;
        float keyScale = screenWidth / keyWidth / 6;
        int numberOfKeys = 1 + prefabWrongButtons.Length;
        float keyPositionWidth = screenWidth / (numberOfKeys+2);
        float keyPositionHeight = screenHeight / 2.5f;
        
        Debug.Log(screenWidth);

        //createCorrectButton();
        int indexOfCorrectKey = Random.Range(0, numberOfKeys);


        //createFalseButtons();
        int indexOfWrongKey = 0;

        for (int i = 1; i <= numberOfKeys; i++)
        {
            if (i - 1 == indexOfCorrectKey)
            {
                GameObject goButton = (GameObject)Instantiate(prefabCorrectButton);
                goButton.transform.SetParent(parentPanel, false);

                goButton.transform.localScale = new Vector3(keyScale, keyScale, keyScale);
                goButton.transform.position = Camera.main.transform.position + new Vector3(keyPositionWidth * i, keyPositionHeight, 0);
                goButton.gameObject.SetActive(true);

                Button tempButton = goButton.GetComponent<Button>();
                int tempInt = i;

                tempButton.onClick.AddListener(() => correctButtonClicked(tempInt));
            }
            else
            {
                GameObject goButton = (GameObject)Instantiate(prefabWrongButtons[indexOfWrongKey]);
                goButton.transform.SetParent(parentPanel, false);

                goButton.transform.localScale = new Vector3(keyScale, keyScale, keyScale);
                goButton.transform.position = Camera.main.transform.position + new Vector3(keyPositionWidth * i, keyPositionHeight, 0);
                goButton.gameObject.SetActive(true);

                Button tempButton = goButton.GetComponent<Button>();
                int tempInt = i;

                tempButton.onClick.AddListener(() => wrongButtonClicked(tempInt));
                indexOfWrongKey += 1;
            }
        }
        audioIndication.gameObject.SetActive(true);
        audioIndication.Play();
    }

    void correctButtonClicked(int buttonNo)
    {
        Debug.Log("Correct Button clicked = " + buttonNo);
        score = score + (10 - penalty);
        goToNextLevel();
    }
    void wrongButtonClicked(int buttonNo)
    {
        Debug.Log("Wrong Button clicked = " + buttonNo);
        penalty += 2;
    }

    void goToNextLevel()
    {
        if(nextLevel == null)
        {
            // last level
            Debug.Log("Total score is = " + score);
            parentPanel.gameObject.SetActive(false);
            nextGame.SetActive(true);
        }
        else
        {
            parentPanel.gameObject.SetActive(false);
            nextLevel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
