using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private bool EndGame = false;
    private bool GoToPlanet = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameObject.Find("Canvas").GetComponent <Score> ().GoPlanet)
        {
            GoToPlanet = true;   
        }
        else
        {
            GoToPlanet = false;
        }
        
        if(GoToPlanet == true)
        {
            
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "MothershipCheckpoint" && EndGame == true)
        {
            Debug.Log("Je hebt gewonnen");
        }

        if (col.gameObject.name == "PlanetCheckpoint" && GoToPlanet == true)
        {
            Debug.Log("Je Bent Bij De Planet");
            EndGame = true;
        }
    }
}
