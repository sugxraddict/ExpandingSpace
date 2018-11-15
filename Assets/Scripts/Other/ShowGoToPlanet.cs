using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGoToPlanet : MonoBehaviour
{

    public GameObject GoToPlanet;
    public GameObject GoToMothership;
    public GameObject BeginInstructions;

    bool ShowGoToPlanetText = false;
    bool ShowGoToMothershipText = false;
    bool BeginInstructionsText = false;
    bool ColWithPlanet = false;

    public bool text1 = true;
    public bool text2 = true;
    public bool text3 = true;

    bool paused = false;
    // Use this for initialization
    void Start()
    {
        text1 = true;
        text2 = true;
        text3 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<Score>().GoPlanet == true)
        {
            ShowGoToPlanetText = true;
        }

        if (ShowGoToPlanetText == true && text1 == true)
        {
            GoToPlanet.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 1"))
            {
                text1 = false;
                Time.timeScale = 1f;
            }
        }
        else
        {
            GoToPlanet.SetActive(false);
        }

        // GO TO MOTHERSHIP!

        if (GameObject.Find("Player(Clone)").GetComponent<MissionObjectivePoints>().EndGame == true)
        {
            ShowGoToMothershipText = true;
        }

        if (ShowGoToMothershipText == true && text2 == true)
        {
            GoToMothership.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 1"))
            {
                text2 = false;
                Time.timeScale = 1f;
            }
        }
        else
        {
            GoToMothership.SetActive(false);
        }

        //INSTRUCTIONS IN THE BEGIN!

        if (GameObject.Find("Canvas").GetComponent<Timer>().timePassed >= 1 && text3 == true)
        {
            BeginInstructions.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 1"))
            {
                text3 = false;
                Time.timeScale = 1f;
            }
        }
        else
        {
            BeginInstructions.SetActive(false);
        }
    }
}
