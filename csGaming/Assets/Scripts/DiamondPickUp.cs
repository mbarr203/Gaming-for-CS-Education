using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DiamondPickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject diamond;
	// Use this for initialization
	void Start () {
		
	}

    static void DoBeep()
    {
        EditorApplication.Beep();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            DoBeep();
            diamond.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            DoBeep();
            diamond.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            DoBeep();
            diamond.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
