using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour {

    public GameObject[] correctItems;
    public static int score = 0;
    public static int correctDeleted = 0;
    public GameObject nextGame;

    void Update()
    {
        if(correctItems.Length == correctDeleted)
        {
            Debug.Log("finished with score " + score);
            this.gameObject.SetActive(false);
            nextGame.SetActive(true);
        }
    }

}
