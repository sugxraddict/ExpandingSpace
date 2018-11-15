using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivePoints : MonoBehaviour {

    public bool End = false;
    public bool EndGame = false;
    public bool GoToPlanet = false;
    bool ShowCheckpointPlanet = true;
    public GameObject PlanetCheckpoint;
    public GameObject MothershipCheckpoint;

    // Use this for initialization
    void Start () {
        GoToPlanet = false;
        ShowCheckpointPlanet = true;
        PlanetCheckpoint = GameObject.FindWithTag("PlanetCheckpoint");
        MothershipCheckpoint = GameObject.FindWithTag("MSCP");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<Score>().GoPlanet == true && ShowCheckpointPlanet == true)
        {
            GoToPlanet = true;
        }

        if (GoToPlanet == true)
        {
            PlanetCheckpoint.SetActive(true);
        }
        else
        {
            PlanetCheckpoint.SetActive(false);
        }

        if(EndGame == true)
        {
            MothershipCheckpoint.SetActive(true);
        }
        else
        {
            MothershipCheckpoint.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "MothershipCheckpoint" && EndGame == true)
        {
            EventManager.onPlayerWin();
        }

        if (col.gameObject.name == "PlanetCheckpoint" && GoToPlanet == true)
        {
            //Hier moet nog een popup message ofzo komen om spelen te informeren!
            ShowCheckpointPlanet = false;
            EndGame = true;
        }
    }
}
