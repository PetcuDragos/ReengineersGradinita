using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenScript : MonoBehaviour
{

    public static bool settingsIsActive = false;
    public static bool mainScreenIsActive = true;
    public static bool gameIsActive = false;

    public GameObject mainScreenUI;
    public GameObject settingsUI;
    public GameObject gameUI;

    // Start is called before the first frame update
    void Start()
    {
        mainScreenUI.SetActive(mainScreenIsActive);
        settingsUI.SetActive(settingsIsActive);
        gameUI.SetActive(gameIsActive);
    }

    // Update is called once per frame
    void Update()
    {
        mainScreenUI.SetActive(mainScreenIsActive);
        settingsUI.SetActive(settingsIsActive);
        gameUI.SetActive(gameIsActive);
    }
}
