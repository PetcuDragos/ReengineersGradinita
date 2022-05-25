using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Child_SetChildNameOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button childIconBtn = GetComponentInChildren<Button>();
        string childName = GetComponentInChildren<TMP_InputField>()?.text;
        childIconBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.ChildName = childName;
        });
    }
}
