using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRootGame : MonoBehaviour
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
        StartRootGame[] myItems = FindObjectsOfType(typeof(StartRootGame)) as StartRootGame[];
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
