using System.Collections;
using System.Collections.Generic;
using GameState;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Child_SetChildNameOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ATTENTION: Getting the names on Start Event requires the names to already be set in the Start Event of LoadChildrenNames,
        // BUT, the order of the Start Events is not deterministic, so some/all names may not be initialized
        
        // Previous code: (for demonstration purposes only)
        //  string childName = GetComponentInChildren<TMP_InputField>()?.text;
        //  Debug.Log($"SetChildName+LoadScores, Child '{childName}' - START");
        
        Button childIconBtn = GetComponentInChildren<Button>();
        childIconBtn.onClick.AddListener(() =>
        {
            // HOWEVER, Click Events will happen after any Start Events, so getting the name on Click ensures that all names are already set 
            string childName = GetComponentInChildren<TMP_InputField>()?.text;
            GameManager.Instance.ChildName = childName;
            GameManager.Instance.LoadScoreForCurrentChild();
        });
    }
}
