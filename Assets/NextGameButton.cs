using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NextGameButton : MonoBehaviour
{

    public GameObject currentGame;
    public GameObject nextGame;
    public bool saveScoresOnClick;
    private Button button;
    public bool confirmation;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        ConfirmationScript dialog = ConfirmationScript.Instance();
        dialog.Hide();
        button.onClick.AddListener(() => OnClick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (confirmation)
        {
            currentGame.SetActive(false);
            ConfirmationScript dialog = ConfirmationScript.Instance();
            dialog.OnAccept("Yes", () => { // define what happens when user clicks Yes:
                if (saveScoresOnClick)
                    GameManager.Instance.SaveScoreForCurrentChild();
                currentGame.SetActive(false);
                nextGame.SetActive(true);
            });
            dialog.OnDecline("No", () =>
            {
                dialog.Hide();
                currentGame.SetActive(true);
            });
            dialog.Show();
        }
        else
        {
            if (saveScoresOnClick)
                GameManager.Instance.SaveScoreForCurrentChild();
            currentGame.SetActive(false);
            nextGame.SetActive(true);
        }
    }
}
