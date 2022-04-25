using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsButtonScript : MonoBehaviour
{

    public Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = settingsButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        MainScreenScript.settingsIsActive = true;
        MainScreenScript.mainScreenIsActive = false;
        MainScreenScript.gameIsActive = false;
    }
}
