using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadChildrenNames : MonoBehaviour
{
    public static LoadChildrenNames instance;
    private string _namesFilePath;
    public GameObject[] childNameFieldsTeacherUI;
    public GameObject[] childNameFieldsStudentUI;
    public GameObject kindergartenGroupField;
    public GameObject kindergartenGroupFieldStudentUI;
    public GameObject saveButton;
    // Start is called before the first frame update

    public string getGroupName()
    {
        return kindergartenGroupField.GetComponent<TMP_InputField>().text;
    }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        instance = this;
        _namesFilePath = Application.dataPath + "/" + "nume_copii.csv";
        LoadAllNames();
        for(int i = 0; i < childNameFieldsTeacherUI.Length; i ++)
        {
            childNameFieldsTeacherUI[i].GetComponent<TMP_InputField>().onValueChanged.AddListener((v) => { saveButton.SetActive(true); });
        }
        saveButton.GetComponent<Button>().onClick.AddListener(() => { SaveChildrenNames(); });
    }

    public void LoadAllNames()
    {
        if (File.Exists(_namesFilePath))
        {
            var prevScores = File.ReadAllText(_namesFilePath);

            int index = -1;
            foreach (var row in prevScores.Split(Environment.NewLine))
            {
                if(index == -1)
                {
                    // we take first line of text which is name of the kindergarten group
                    Debug.Log("grupa " + row);
                    kindergartenGroupField.GetComponent<TMP_InputField>().text = row;
                    kindergartenGroupFieldStudentUI.GetComponent<TMP_Text>().text = row;
                }
                else if(index < childNameFieldsTeacherUI.Length)
                {
                   
                        childNameFieldsTeacherUI[index].GetComponent<TMP_InputField>().text = row;
                        childNameFieldsStudentUI[index].GetComponent<TMP_InputField>().text = row;
                         
                }
                index++;
            }
        }
    }

    public void SaveChildrenNames()
    {

        StringBuilder result = new StringBuilder();
        result.Append(kindergartenGroupField.GetComponent<TMP_InputField>().text);
        result.Append($"{Environment.NewLine}");

        for (int i = 0; i < childNameFieldsTeacherUI.Length; i++)
        {
            result.Append(childNameFieldsTeacherUI[i].GetComponent<TMP_InputField>().text);
            result.Append($"{Environment.NewLine}");
        }
        File.WriteAllText(_namesFilePath, result.ToString());
        LoadAllNames();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
