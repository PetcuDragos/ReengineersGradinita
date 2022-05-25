using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextGameButton : MonoBehaviour
{

    public GameObject currentGame;
    public GameObject nextGame;
    public bool saveScoresOnClick;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => OnClick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (saveScoresOnClick)
            GameManager.Instance.SaveScoreForCurrentChild();
        currentGame.SetActive(false);
        nextGame.SetActive(true);
    }
}
