using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSceneScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip intro;
    private bool soundStopped = false;
    private bool soundStarted = false;
    public GameObject currentScene;
    public GameObject nextScene;
    // Start is called before the first frame update
    void Start()
    {
        if (intro != null)
        {
            source.clip = intro;
            source.Play();
            soundStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying && soundStarted)
        {
            soundStopped = true;
        }

        if (soundStopped)
        {
            currentScene.SetActive(false);
            nextScene.SetActive(true);
        }
    }
}
