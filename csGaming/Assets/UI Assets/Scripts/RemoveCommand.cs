using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RemoveCommand : MonoBehaviour {

	//public GameObject commandPrefab;
	public GameObject deleteSign;

	// Use this for initialization
	void Start () {
		Button deleteButton = deleteSign.GetComponent<Button>();
		deleteButton.onClick.AddListener(Delete);
		
	}

	void Delete(){
		
		Destroy (transform.parent. gameObject);
			

	}
	// Update is called once per frame
	void Update () {
		
	}
}
