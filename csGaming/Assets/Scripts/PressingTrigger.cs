using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressingTrigger : MonoBehaviour {

	public BlocksRotator bl;

	void Start() {
		bl = GameObject.FindObjectOfType<BlocksRotator>();
	}
	
	void OnMouseDown()
    {

		transform.localScale = new Vector3(0.8F, 0.01f, 0.8f);
		bl.Rotate();
    }
}
