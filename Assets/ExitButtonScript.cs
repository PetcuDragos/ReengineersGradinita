using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => ExitApplication());
    }

    private void ExitApplication()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
