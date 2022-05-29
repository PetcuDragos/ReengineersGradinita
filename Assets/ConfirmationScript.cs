using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class ConfirmationScript : MonoBehaviour
{
    public Button acceptButton, declineButton;
    public AudioSource audioSource;
    public AudioClip confirmationMessage;


    private CanvasGroup cg;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    public ConfirmationScript OnAccept(string text, UnityAction action)
    {
        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(action);
        return this;
    }



    public ConfirmationScript OnDecline(string text, UnityAction action)
    {
        declineButton.onClick.RemoveAllListeners();
        declineButton.onClick.AddListener(action);
        return this;
    }

    // show the dialog, set it's canvasGroup.alpha to 1f or tween like here
    public void Show()
    {
        this.transform.SetAsLastSibling();
        cg.interactable = true;
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
        audioSource.clip = confirmationMessage;
        audioSource.Play();
    }

    public void Hide()
    {
        audioSource.Stop();
        this.cg.alpha = 0f;
        this.cg.interactable = false;
        this.cg.blocksRaycasts = false;
    }

    private static ConfirmationScript instance;
    public static ConfirmationScript Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(ConfirmationScript)) as ConfirmationScript;
            if (!instance)
                Debug.Log("There need to be at least one active GenericDialog on the scene");
        }

        return instance;
    }

}
