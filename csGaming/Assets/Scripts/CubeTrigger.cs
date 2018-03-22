using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            print("Trigger activated!");
            other.transform.position = new Vector3(-9,9,-5);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            print("Trigger activated!");
            other.transform.position = new Vector3(-9, 9, -5);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            print("Trigger activated!");
            other.transform.position = new Vector3(-9, 9, -5);
        }
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
