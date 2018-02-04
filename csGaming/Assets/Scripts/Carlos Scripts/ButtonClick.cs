using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button upButton;
    public Button downButton;

    public string[] commandList;
    public GameObject textObject;
    public string buttonName;
    public int i = 0;
    
	// Use this for initialization
	void Start ()
    {
        Button btn = leftButton.GetComponent<Button>();
        Button btn1 = rightButton.GetComponent<Button>();
        Button btn2 = upButton.GetComponent<Button>();
        Button btn3 = downButton.GetComponent<Button>();

        commandList = new string[10];

        btn.onClick.AddListener(TaskOnClick);
        btn1.onClick.AddListener(TaskOnClick);
        btn2.onClick.AddListener(TaskOnClick);
        btn3.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick()
    {
        Debug.Log("You clicked on a button!");

        textObject = EventSystem.current.currentSelectedGameObject;
        string btnText = textObject.GetComponentInChildren<Text>().text;
        if (i < 10)
        {
            commandList[i] = btnText;
            i++;
        }
        else
        {
            print("No more commands may be issued!");
        }
	}
}
