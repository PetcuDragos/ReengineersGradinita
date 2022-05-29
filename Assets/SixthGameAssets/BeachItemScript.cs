using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BeachItemScript : MonoBehaviour
{
    public static event Action OnCorrectAnswer; 
    public static event Action OnWrongAnswer; 
    
    public GameObject[] correctTargets;
    public GameObject[] wrongTargets;
    private bool isBeingHeld = false;
    public AudioSource audioSource;
    public AudioClip wrong;
    public AudioClip correct;

    public void OnMouseDown()
    {
        isBeingHeld = true;

    }
    public void OnMouseUp()
    {
        isBeingHeld = false;

    }

    private void Start()
    {
        for(int i =0; i < correctTargets.Length; i ++)
        {
            correctTargets[i].SetActive(true);
        }
        for (int i = 0; i < wrongTargets.Length; i++)
        {
            wrongTargets[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);

            for (int i = 0; i < correctTargets.Length; i++)
            {
                if (correctTargets[i].GetComponent<Collider2D>().IsTouching(this.gameObject.GetComponent<Collider2D>()))
                {
                    OnCorrectAnswer?.Invoke();
                    BeachGameScript.numberOfTrashItemsFound += 1;
                    this.gameObject.SetActive(false);
                    audioSource.clip = correct;
                    audioSource.Play();
                }
            }
            for (int i = 0; i < wrongTargets.Length; i++)
            {
                if (wrongTargets[i].GetComponent<Collider2D>().IsTouching(this.gameObject.GetComponent<Collider2D>()))
                {
                    OnWrongAnswer?.Invoke();
                    this.gameObject.SetActive(false);
                    audioSource.clip = wrong;
                    audioSource.Play();
                }
            }

        }
    }
}
