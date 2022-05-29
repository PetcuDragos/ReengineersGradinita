using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLevelScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip final;
    public AudioClip instruction;
    public AudioClip invalidNeighbourAudioClip;
    public AudioClip invalidAudioClip;
    public AudioClip invalidPoliceAudioClip;
    public GameObject currentTile;
    public GameObject endingTile;
    public GameObject[] tiles;
    public GameObject currentLevel;
    public GameObject nextLevel;
    public GameObject instructionButton;
    private bool introStarted = false;
    private bool introEnded = false;
    private bool finalStarted = false;
    private bool finalEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        instructionButton.GetComponent<Button>().onClick.AddListener(() => ReplayInstruction());
        if (intro != null)
        {
            audioSource.clip = intro;
            audioSource.Play();
        }
        else
        {
            introEnded = true;
        }
        introStarted = true;
        for (int i = 0; i < tiles.Length; i++)
        {
            int y = i;
            tiles[i].GetComponent<Button>().onClick.AddListener(() => { CheckMoveToTile(tiles[y]); });
        }
    }

    private void CheckMoveToTile(GameObject tile)
    {
        GameObject[] validNeighbours = currentTile.GetComponent<IslandScript>().validNeighbours;
        GameObject[] invalidNeighbours = currentTile.GetComponent<IslandScript>().invalidNeighbours;
        GameObject[] invalidPoliceNeighbours = currentTile.GetComponent<IslandScript>().invalidPoliceNeighbours;

        for(int i = 0; i < validNeighbours.Length; i ++)
        {
            if(validNeighbours[i] == tile)
            {
                Debug.Log("egale");
                MoveToTile(tile);
                return;
            }
        }
        for (int i = 0; i < invalidNeighbours.Length; i++)
        {
            if (invalidNeighbours[i] == tile)
            {
                Debug.Log("egale invalid neigbours");
                audioSource.clip = invalidNeighbourAudioClip;
                audioSource.Play();
                return;
            }
        }
        for (int i = 0; i < invalidPoliceNeighbours.Length; i++)
        {
            if (invalidPoliceNeighbours[i] == tile)
            {
                Debug.Log("egale invalid police");
                audioSource.clip = invalidPoliceAudioClip;
                audioSource.Play();
                return;
            }
        }
        audioSource.clip = invalidAudioClip;
        audioSource.Play();
    }

    private void MoveToTile(GameObject tile)
    {
        Sprite tileSprite = tile.GetComponent<Image>().sprite;
        tile.GetComponent<Image>().sprite = this.currentTile.GetComponent<Image>().sprite;
        this.currentTile.GetComponent<Image>().sprite = tileSprite;

        this.currentTile = tile;
        if(this.currentTile == endingTile)
        {
            EndLevel();
        }
    }

    private void EndLevelHandler()
    {
        if (final != null)
        {
            audioSource.clip = final;
            audioSource.Play();
        }
        finalStarted = true;
    }

    private void EndLevel()
    {
        currentLevel.SetActive(false);
        if (nextLevel == null)
        {
            TrafficGameScript.gameEnded = true;
        }
        else
        {
            nextLevel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(finalStarted && !finalEnded && !audioSource.isPlaying)
        {
            finalEnded = true;
            EndLevel();
        }
    }

    private void ReplayInstruction()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = instruction;
            audioSource.Play();
        }
    }
}
