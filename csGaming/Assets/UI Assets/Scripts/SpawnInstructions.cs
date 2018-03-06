using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnInstructions : MonoBehaviour {

	public Button moveRight;
	public Button moveLeft;
	public Button moveUp;
	public Button moveDown;

	public Canvas background;
	public Button[] buttons;

	void Start()
	{
		Debug.Log ("You have started");

		//Button moveRightButton = moveRight.GetComponent<Button>();
		moveRight.onClick.AddListener(MoveRight);

		Button moveLeftButton = moveLeft.GetComponent<Button>();
		moveLeftButton.onClick.AddListener(MoveLeft);

		Button moveUpButton = moveUp.GetComponent<Button>();
		moveUpButton.onClick.AddListener(MoveUp);

		Button moveDownButton = moveDown.GetComponent<Button>();
		moveDownButton.onClick.AddListener(MoveDown);

		//Disable all command buttons at the beginning of scene 
		int i = 0;
		while (i < buttons.Length) 
		{
			buttons [i].gameObject.SetActive (false);
			i++;
		}
			

	}

	void Update()
	{
		
	}

	 void MoveRight()
	{
		Debug.Log ("You have clicked the move right button");
		int i = 0;
		while (i < buttons.Length) 
		{
			if (buttons [i].GetComponentInChildren<Text> ().text.Equals ("")) 
			{
				buttons[i].gameObject.SetActive (true);
				buttons[i].GetComponentInChildren<Text> ().text = "Player.MoveRight()";
				break;
			}
				i++;
			Debug.Log ("You have clicked the move right button");
		}


		/*GameObject newBtn;

		newBtn = Instantiate (btnPrefab, transform.position , transform.rotation) as GameObject;
		newBtn.transform.position = new Vector3 (743f,283f , 0);
		newBtn.transform.rotation = btnPrefab.transform.localRotation;
		//transform.localPosition = Camera.main.ViewportToWorldPoint(pos);
		newBtn.transform.SetParent(background.transform, false);

		Debug.Log("The position is" + newBtn.transform.localPosition.ToString());*/

	}

	public void MoveLeft()
	{
		int i = 0;
		while (i < buttons.Length) 
		{
			if (buttons [i].GetComponentInChildren<Text> ().text.Equals ("")) 
			{
				buttons[i].gameObject.SetActive (true);
				buttons [i].GetComponentInChildren<Text> ().text = "Player.MoveLeft()";
				break;
			}
			i++;
		}
	}

	public void MoveUp()
	{
		int i = 0;
		while (i < buttons.Length) 
		{
			if (buttons [i].GetComponentInChildren<Text> ().text.Equals ("")) 
			{
				buttons[i].gameObject.SetActive (true);
				buttons [i].GetComponentInChildren<Text> ().text = "Player.MoveUp()";
				break;
			}
			i++;
		}
	}

	void MoveDown()
	{
		int i = 0;
		while (i < buttons.Length) 
		{
			if (buttons [i].GetComponentInChildren<Text> ().text.Equals ("")) 
			{
				buttons[i].gameObject.SetActive (true);
				buttons [i].GetComponentInChildren<Text> ().text = "Player.MoveDown()";
				break;
			}
			i++;
		}
	}



}
