using GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSceneScript : MonoBehaviour
{
    public GameObject animation;
    private UnityEngine.Video.VideoPlayer castlePlayer;
    public AudioSource source;
    public AudioClip intro;
    private bool animationStopped = false;
    private bool soundStopped = false;
    private bool soundStarted = false;
    private bool animationStarted = false;
    public GameObject currentScene;
    public GameObject nextScene;
    public GameObject currentGame;
    public GameObject nextGame;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Score[Game.Three] != -1)
        {
            currentGame.SetActive(false);
            nextGame.SetActive(true);
        }
        else
        {
            castlePlayer = animation.GetComponent<UnityEngine.Video.VideoPlayer>();
            if (intro != null)
            {
                source.PlayOneShot(intro);
                soundStarted = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (castlePlayer.isPlaying)
        {
            animationStarted = true;
        }
        else if(animationStarted)
        {
            animationStopped = true;
        }

        if(!source.isPlaying && soundStarted)
        {
            soundStopped = true;
        }

        if (animationStopped && soundStopped)
        {
            currentScene.SetActive(false);
            nextScene.SetActive(true);
        }
       

    }
}
