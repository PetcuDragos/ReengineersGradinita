using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGamesHandler : MonoBehaviour
{
    public GameObject rootGame;
    private GameObject currentInstance;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick()
    {
        Canvas[] myItems = FindObjectsOfType(typeof(Canvas)) as Canvas[];
        Debug.Log("Found " + myItems.Length + " instances with this script attached");
        if (currentInstance != null)
        {
            Debug.Log("okay");
            Destroy(currentInstance);
        }
        currentInstance = Instantiate(rootGame);
        currentInstance.SetActive(true);
    }
}
