using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
   // TrailRenderer trail;
    Light thrusterLight;

    void Awake()
    {
      //  trail = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    void Start()
    {
        //trail.enabled = false;
        //thrusterLight.enabled = false;
        thrusterLight.intensity = 0;
    }


   /* public void Activate(bool activate = true)
    {
        if(activate)
        {
            trail.enabled = true;
            thrusterLight.enabled = true;

            //turn on partical
            //turn on sound
            //etc
        }
        else
        {
            trail.enabled = false;
            thrusterLight.enabled = false;
            //turn off everything from Thruster
        }
    }*/

    public void Intensity(float inten)
    {
        thrusterLight.intensity = inten * 2f;
    }
}
